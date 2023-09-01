using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid format email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, ErrorMessage = "the {0} must be at least {2} and max {1} characters long", MinimumLength = 5)]
    public string Password { get; set; }
}