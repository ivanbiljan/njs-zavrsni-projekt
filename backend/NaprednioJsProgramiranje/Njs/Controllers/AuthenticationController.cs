using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Njs.Core.Features.Authentication;
using Njs.Core.Features.Products;

namespace Njs.Controllers;

[ApiController]
[Route("api/auth")]
[AllowAnonymous]
public sealed class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<RegisterUserResponse> Register([FromForm] RegisterUserRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPost("login")]
    public async Task<LoginUserResponse> Login([FromForm] LoginUserRequest request)
    {
        return await _mediator.Send(request);
    }
}

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