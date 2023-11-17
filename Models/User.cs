using System.ComponentModel.DataAnnotations;

namespace Ecommerceapi.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }

}