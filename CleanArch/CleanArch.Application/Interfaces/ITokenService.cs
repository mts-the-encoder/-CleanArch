using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface ITokenService
{
    Task<UserToken> AuthenticateAndGenerateToken(LoginDto user);
}