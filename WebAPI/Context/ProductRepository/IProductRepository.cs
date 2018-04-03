using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public interface IProductRepository
    {
        IEnumerable<Category> GetAllCategories();

        IEnumerable<Product> GetAllProductsByCategoryId(int categoryId);

        Product GetProductById(int id);

        void Dispose();
    }
}