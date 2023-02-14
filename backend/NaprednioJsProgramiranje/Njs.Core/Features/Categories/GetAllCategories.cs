using MediatR;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Infrastructure.Multitenancy;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core.Features.Categories;

public sealed record GetAllCategoriesRequest : IRequest<IEnumerable<CategoryDto>>;

public sealed record GetAllCategoriesResponse(IEnumerable<CategoryDto> Categories);

public sealed record CategoryDto(string Name, string Description, string LogoUrl);

public sealed class GetAllCategoriesQuery : IRequestHandler<GetAllCategoriesRequest, IEnumerable<CategoryDto>>
{
    private readonly NjsContext _db;

    public GetAllCategoriesQuery(NjsContext db)
    {
        _db = db;
    }
    
    public Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = _db.Categories.Select(c => new CategoryDto(c.Name, c.Description, c.LogoUrl)).AsEnumerable();

        return Task.FromResult(categories);
    }
}