using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Njs.Core.Features.Authentication;

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

    [HttpPost("confirm")]
    public async Task<IActionResult> ConfirmAccount([FromBody] ConfirmAccountRequest request)
    {
        var response = await _mediator.Send(request);

        return response switch
        {
            ConfirmAccountResponse.LinkExpiredOrInvalid => BadRequest(),
            ConfirmAccountResponse.Activated => Conflict(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}