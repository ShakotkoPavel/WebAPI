using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public interface IProductRepository
    {
        void Dispose();

        IEnumerable<Category> GetAllCategories();

        IEnumerable<Product> GetAllProductsByCategoryId(int categoryId);

        Product GetProductById(int id);
    }
}