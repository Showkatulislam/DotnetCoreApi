using Ecommerceapi.Models;
namespace Ecommerceapi.Interfaces;

public interface ICategoryService
{
    List<Category> getAll();
    Category AddGategory(Category category);
    bool DeleteCategory(int id);
    Category GetCategoryById(int id);

}