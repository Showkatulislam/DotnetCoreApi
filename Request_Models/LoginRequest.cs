namespace Ecommerceapi.Request_Models;
using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}