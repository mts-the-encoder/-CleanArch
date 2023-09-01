using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authenticate;
    private readonly ITokenService _service;
    public TokenController(IAuthenticate authenticate, ITokenService service)
    {
        _authenticate = authenticate;
        _service = service;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserToken>> Login(LoginDto user)
    {
        await _authenticate.Authenticate(user.Email, user.Password);

        return await _service.AuthenticateAndGenerateToken(user);
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register(RegisterDto user)
    {
        await _authenticate.RegisterUser(user.Email, user.Password);

        return Created(string.Empty, $"User {user.Email} created with successfully");
    }
}