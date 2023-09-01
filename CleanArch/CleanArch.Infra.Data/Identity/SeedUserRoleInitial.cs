using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("user@localhost").Result is null)
        {
            var user = new ApplicationUser
            {
                UserName = "user@localhost",
                Email = "user@localhost",
                NormalizedUserName = "USER@LOCALHOST",
                NormalizedEmail = "USER@LOCALHOST",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var response = _userManager.CreateAsync(user, "Urubu100@").Result;

            if (response.Succeeded)
                _userManager.AddToRoleAsync(user, "User").Wait();
        }

        if (_userManager.FindByEmailAsync("admin@localhost").Result is null)
        {
            var admin = new ApplicationUser
            {
                UserName = "admin@localhost",
                Email = "admin@localhost",
                NormalizedUserName = "ADMIN@LOCALHOST",
                NormalizedEmail = "ADMIN@LOCALHOST",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var response = _userManager.CreateAsync(admin,"Urubu100@").Result;

            if (response.Succeeded)
                _userManager.AddToRoleAsync(admin,"Admin").Wait();
        }
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("User").Result)
        {
            var role = new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
            };

            var roleResponse = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            };

            var roleResponse = _roleManager.CreateAsync(role).Result;
        }
    }
}