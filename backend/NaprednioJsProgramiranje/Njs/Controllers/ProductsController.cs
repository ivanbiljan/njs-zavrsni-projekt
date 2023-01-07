using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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