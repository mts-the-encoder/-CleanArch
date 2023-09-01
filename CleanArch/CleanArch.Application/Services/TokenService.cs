using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace CleanArch.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IAuthenticate _authenticate;
    public TokenService(IConfiguration configuration, IAuthenticate authenticate)
    {
        _configuration = configuration;
        _authenticate = authenticate;
    }

    private UserToken GenerateToken(LoginDto user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("key", "CSharp"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"] ?? string.Empty));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(13);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new UserToken()
        {
            Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }

    public async Task<UserToken> AuthenticateAndGenerateToken(LoginDto user)
    {
        var response = await _authenticate.Authenticate(user.Email, user.Password);

        if (!response) throw new ApplicationException("Error on Generate Token");
        
        var result = GenerateToken(user);
        return result;
    }
}