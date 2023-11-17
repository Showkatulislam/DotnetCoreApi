using Ecommerceapi.Interfaces;
using Ecommerceapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceapi.Controllers;
[ApiController]
[Route("[controller]")]

public class CategoryController:ControllerBase
{
    private readonly ICategoryService categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService=categoryService;
    }
    [HttpGet]
    public IActionResult Getall(){
       return Ok(categoryService.getAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById([FromRoute] int id){
        return Ok(categoryService.GetCategoryById(id));
    }

    [HttpPost]

    public IActionResult AddProduct([FromBody] Category category){
        return Ok(categoryService.AddGategory(category));
    }
    [HttpDelete]
    public IActionResult RemoveProduct([FromQuery] int id){
        System.Console.WriteLine("ddddddddddddddddd",id);
        return Ok(categoryService.DeleteCategory(id));
    }

}
