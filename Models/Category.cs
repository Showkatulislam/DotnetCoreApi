using System.ComponentModel.DataAnnotations;

namespace Ecommerceapi.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CatagoryName { get; set; } = "";
}
