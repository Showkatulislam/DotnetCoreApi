
using Ecommerceapi.Context;
using Ecommerceapi.Interfaces;
using Ecommerceapi.Models;
namespace Ecommerceapi.Services;
public class ProductService:IProductService
{
    private readonly DataContext dataContext;

    public ProductService(DataContext dataContext)
    {
        this.dataContext=dataContext;
    }

    public List<Product> GetProducts(){
        var products=dataContext.Products.ToList();
        return products;
    }

    public Product AddProduct(Product product){
        var _product=dataContext.Products.Add(product);
        dataContext.SaveChanges();
        return _product.Entity;
    }
    public bool DeleteProduct(int id){
        var product=dataContext.Products.SingleOrDefault(p=>p.ProductId==id);
        if(product==null){
            throw new Exception("Product doestn't exist.");
        }else{
            dataContext.Products.Remove(product);
            dataContext.SaveChanges();
            return true;
        }
    }
    public Product UpdateProduct(Product product){
        var _product=dataContext.Products.Update(product);
        return _product.Entity;
    }
}