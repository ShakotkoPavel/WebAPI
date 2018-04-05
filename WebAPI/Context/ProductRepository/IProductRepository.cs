using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public interface IProductRepository
    {
        Product GetProductById(int id);

        IEnumerable<string> GetAllCategories();

        IEnumerable<string> GetAllProductsByCategoryId(int categoryId);

        void AddProductToCart(int productId, string messengerId);

        void BuyProducts(Account account);

        bool CheckBalance(string messengerId);

        decimal GetSumOfProducts(Account account);

        Account GetAccount(string messengerId);
        //void Dispose();
    }
}