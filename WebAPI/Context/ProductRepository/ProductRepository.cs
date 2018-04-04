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

        public IEnumerable<Product> GetAllProductsByCategoryId(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category != null)
            {
                return db.Products.Include(p => p.Category).Where(x => x.Category.Id == categoryId).ToList();
            }
            return Enumerable.Empty<Product>();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories;
        }

        public Product GetProductById(int id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProductToCart(int productId, int messengerId)
        {
            var cart = db.Carts.FirstOrDefault(x => x.Account.MessengerId == messengerId);

            if (cart != null)
            {
                var newCart = new Cart { };
            }
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