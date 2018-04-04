using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public interface IProductRepository
    {
        Product GetProductById(int id);

        IEnumerable<Category> GetAllCategories();

        IEnumerable<Product> GetAllProductsByCategoryId(int categoryId);

        void AddProductToCart(int productId, string messengerId);

        void BuyProducts(string messengerId);

        Account GetAccount(string messengerId);

        decimal GetSumOfProducts(Account account);
        //void Dispose();
    }
}