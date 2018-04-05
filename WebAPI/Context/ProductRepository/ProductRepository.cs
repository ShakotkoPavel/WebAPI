using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public class ProductRepository : IProductRepository//, IDisposable
    {
        private readonly DataContext db;

        public ProductRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<string> GetAllProductsByCategoryId(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category != null)
            {
                return db.Products.Include(p => p.Category).Where(x => x.Category.Id == categoryId).Select(x => x.Name + x.Price.ToString()).ToList();
            }
            return Enumerable.Empty<string>();
        }

        public IEnumerable<string> GetAllCategories()
        {
            return db.Categories.Select(x => x.Name);
        }

        public Product GetProductById(int id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProductToCart(int productId, string messengerId)
        {
            var account = db.Accounts.FirstOrDefault(x => x.MessengerID == messengerId);
            if (account == null)
            {
                account = new Account { MessengerID = messengerId, Balance = 100 };
                db.Accounts.Add(account);
                db.SaveChanges();
            }

            var cart = db.Carts.FirstOrDefault(x => x.Account.Id == account.Id);
            if(cart == null)
            {
                cart = new Cart { Account = account, DataCreated = DateTime.Now };
                db.Carts.Add(cart);
                db.SaveChanges();
            }

            var product = db.Products.Find(productId);

            if (product != null)
            {
                cart.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void BuyProducts(Account account)
        {
            var cart = db.Carts.FirstOrDefault(x => x.Account.Id == account.Id);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public Account GetAccount(string messengerId)
        {
            return db.Accounts.FirstOrDefault(x => x.MessengerID == messengerId);
        }

        public decimal GetSumOfProducts(Account account)
        {
            var cart = db.Carts.FirstOrDefault(x => x.Account.Id == account.Id);
            var sumOfProducts = cart.Products.Sum(x => x.Price);
            return sumOfProducts;
        }

        public bool CheckBalance(string messengerId)
        {
            var account = GetAccount(messengerId);
            if(account != null)
            {
                var sum = GetSumOfProducts(account);
                if(account.Balance >= sum)
                {
                    return true;
                }
            }
            return false;
        }

        //protected void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (db != null)
        //        {
        //            db.Dispose();
        //            //db = null;
        //        }
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}