using MediatR;
using Njs.Core.Infrastructure.Multitenancy;
using Njs.Core.Infrastructure.Pagination;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core.Features.Products;

public sealed record GetAllProductsRequest(int? CategoryId, int? PageNumber, int? PageSize) : IRequest<GetAllProductsResponse>, IPageable;

public sealed record GetAllProductsResponse(PaginatedList<ProductDto> Products);

public sealed class GetAllProductsQuery : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
{
    private readonly NjsContext _db;

    public GetAllProductsQuery(NjsContext db, ITenantResolver tenantResolver)
    {
        _db = db;
    }
    
    public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = _db.Products.AsQueryable();
        if (request.CategoryId.HasValue)
        {
            products = products.Where(p => p.Categories.Any(c => c.Id == request.CategoryId));
        }

        var results = await products.Select(p => new ProductDto(p.Id, p.Title, p.Description))
            .ToPaginatedListAsync(request);

        return new GetAllProductsResponse(results);
    }
}