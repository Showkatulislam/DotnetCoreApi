using System.Collections;
using Ecommerceapi.Context;
using Ecommerceapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace Ecommerceapi.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController:ControllerBase
{
    private readonly DataContext dataContext;
   public DataController(DataContext dataContext)
   {
     this.dataContext=dataContext;
   }
   [HttpGet]
 
 public async Task<ActionResult<IEnumerable<Product>>> GetAll(){
    if(dataContext.Products==null){
        return NotFound();
    }
    return await dataContext.Products.ToListAsync();
 }

}
