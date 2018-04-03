using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.CategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

        void Dispose();
    }
}