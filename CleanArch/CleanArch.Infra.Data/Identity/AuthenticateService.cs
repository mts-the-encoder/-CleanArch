using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        var response = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

        return response.Succeeded;
    }

    public async Task<bool> RegisterUser(string email, string password)
    {
        var applicationUser = new ApplicationUser { UserName = email, Email = email };

        var response = await _userManager.CreateAsync(applicationUser, password);

        if (!response.Succeeded)
        {
            var errorCause = string.Join(", ",response.Errors.Select(x => x.Description));
            throw new ApplicationException($"Error to create user. cause: {errorCause}");
        }

        await _signInManager.SignInAsync(applicationUser, isPersistent: false);
        return response.Succeeded;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}