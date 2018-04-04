using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public interface IProductRepository
    {
        Product GetProductById(int id);

        IEnumerable<Category> GetAllCategories();

        IEnumerable<Product> GetAllProductsByCategoryId(int categoryId);

        //void Dispose();
    }
}