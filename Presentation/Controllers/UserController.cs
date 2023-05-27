using Application.Abstractions;
using Application.RequestApiModel;
using Application.ResponseApiModel;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Controllers;

[Route("api/user/")]
public sealed class UserController : ApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestApiModel loginRequest,
        CancellationToken cancellationToken)
    {
        var tokenResult = await _userService.Login(loginRequest, cancellationToken);

        return tokenResult.IsFailure ? HandleFailure(tokenResult) : Ok(tokenResult.Value);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestApiModel registerRequest,
        CancellationToken cancellationToken)
    {
        var tokenResult = await _userService.Register(registerRequest, cancellationToken);

        return tokenResult.IsFailure ? HandleFailure(tokenResult) : Ok(tokenResult.Value);
    }

    [HttpGet("get")]
    public async Task<ActionResult<UserResponseApiModel>> GetUser(
        CancellationToken cancellationToken)
    {
        var user = await _userService.GetUser(cancellationToken);

        return user.IsFailure ? HandleFailure(user) : Ok(user.Value);
    }
}