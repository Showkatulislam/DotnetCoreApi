using Ecommerceapi.Interfaces;
using Ecommerceapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceapi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController:ControllerBase{

    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
        this.productService=productService;
    }
    [HttpGet]
    public IActionResult Getall(){
        return Ok(productService.GetProducts());
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] Product product){
        return Ok(productService.AddProduct(product));
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteProduct([FromRoute] int id){
        return Ok(productService.DeleteProduct(id));
    }
    [HttpPut]
    public IActionResult UpdateProduct(Product product){
        return Ok(productService.UpdateProduct(product));
    }
}