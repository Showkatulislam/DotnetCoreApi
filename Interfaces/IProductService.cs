using Ecommerceapi.Models;

namespace Ecommerceapi.Interfaces;
public interface IProductService
{
    List<Product> GetProducts();
    Product AddProduct(Product product);
    Product UpdateProduct(Product product);
    bool DeleteProduct(int id);
}
