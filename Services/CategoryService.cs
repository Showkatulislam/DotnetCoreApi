using Ecommerceapi.Context;
using Ecommerceapi.Interfaces;
using Ecommerceapi.Models;

 namespace Ecommerceapi.Services;

public class CategoryService:ICategoryService
{
    private readonly DataContext dataContext;
    public CategoryService(DataContext dataContext)
    {
        this.dataContext=dataContext;
    }
    public List<Category> getAll(){
       var categories=dataContext.Categories.ToList();
       return categories;
    }

    public Category AddGategory(Category category){
       var _category=dataContext.Categories.Add(category);
       dataContext.SaveChanges();
        return _category.Entity;
    }

    public bool DeleteCategory(int id){
        try
        {
            var category=dataContext.Categories.SingleOrDefault(cat=>cat.CategoryId==id);
            if(category==null){
                return false;
            }else{
                dataContext.Categories.Remove(category);
                dataContext.SaveChanges();
                return true;
            }
        }
        catch (System.Exception)
        {
            
            throw new Exception("Category doesn't exist.");   
        }
    }

    public Category GetCategoryById(int id){
        var category=dataContext.Categories.SingleOrDefault(c=>c.CategoryId==id);
        if(category==null){
           throw new Exception("Category isn't Exist.");
        }
        return category;
    }
}