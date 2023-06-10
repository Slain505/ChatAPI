using System.ComponentModel;
using System.ComponentModel.DataAnnotations;using Microsoft.AspNetCore.Authentication.OAuth.Claims;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should contain from 2-20 characters")]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Surname should contain from 2-20 characters")]
    public string LastName { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Email should contain from 2-20 characters")]
    [EmailAddress(ErrorMessage = "Wrong email format used, try another one")]
    public string Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    [Compare("Password", ErrorMessage = "Incorrect password")]
    public string Password { get; set; }
}
