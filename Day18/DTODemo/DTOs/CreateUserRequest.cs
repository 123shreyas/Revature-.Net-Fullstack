using System.ComponentModel.DataAnnotations;

namespace DtoDemo.DTOs;

public class CreateUserRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}