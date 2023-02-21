using MediatR;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Exceptions;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core.Features.Authentication;

public sealed record ConfirmAccountRequest(string VerificationToken) : IRequest<ConfirmAccountResponse>;

public enum ConfirmAccountResponse
{
    LinkExpiredOrInvalid,
    Activated
}

public sealed class ConfirmAccount : IRequestHandler<ConfirmAccountRequest, ConfirmAccountResponse>
{
    private readonly NjsContext _db;

    public ConfirmAccount(NjsContext db)
    {
        _db = db;
    }

    public async Task<ConfirmAccountResponse> Handle(ConfirmAccountRequest request, CancellationToken cancellationToken)
    {
        var verificationRequest = await _db.VerificationRequests
            .Include(r => r.User)
            .Where(r => r.Token == request.VerificationToken)
            .SingleOrDefaultAsync(cancellationToken);

        if (verificationRequest is null || verificationRequest.HasBeenActivated)
        {
            throw new NjsException("Invalid verification token");
        }

        if (verificationRequest.HasExpired)
        {
            return ConfirmAccountResponse.LinkExpiredOrInvalid;
        }

        return ConfirmAccountResponse.Activated;
    }
}