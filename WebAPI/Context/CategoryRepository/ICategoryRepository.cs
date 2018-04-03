using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.CategoryRepository
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);

        void Delete(int categoryId);

        void Dispose();

        IEnumerable<Category> GetAllCategories();
    }
}