using MediatR;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Infrastructure.Multitenancy;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core.Features.Categories;

public sealed record GetAllCategoriesRequest : IRequest<GetAllCategoriesResponse>;

public sealed record GetAllCategoriesResponse(IEnumerable<CategoryDto> Categories);

public sealed record CategoryDto(string Name, string Description, string LogoUrl);

public sealed class GetAllCategoriesQuery : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
{
    private readonly NjsContext _db;

    public GetAllCategoriesQuery(NjsContext db, ITenantResolver tenantResolver)
    {
        _db = db;
    }
    
    public Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = _db.Categories.Select(c => new CategoryDto(c.Name, c.Description, c.LogoUrl));

        return Task.FromResult(new GetAllCategoriesResponse(categories));
    }
}