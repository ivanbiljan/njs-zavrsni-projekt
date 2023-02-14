using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Features.Categories;
using Njs.Core.Features.Products;

namespace Njs.Controllers;

[ApiController]
[Route("api/products")]
[AllowAnonymous]
public sealed class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<GetAllProductsResponse> GetAll([FromQuery] GetAllProductsRequest request)
    {
        return await _mediator.Send(request);
    }
}

[ApiController]
[Route("api/categories")]
[AllowAnonymous]
public sealed class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAll([FromQuery] GetAllCategoriesRequest request)
    {
        return await _mediator.Send(request);
    }
}