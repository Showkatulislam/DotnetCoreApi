using Ecommerceapi.Models;

namespace Ecommerceapi.Request_Models;
public class ReqProduct
{

    public string Name { get; set; }
    public string Code { get; set; }
    public string BrandName { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public int CatagoryId {get;set;}
    public Category category {get;set;}
}