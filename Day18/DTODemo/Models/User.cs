namespace DtoDemo.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }  // Should NOT be exposed
    public string Email { get; set; }
}