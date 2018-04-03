using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Context.ProductRepository
{
    public class ProductRepository : IDisposable, IProductRepository
    {
        private Context db = new Context();

        public IEnumerable<Product> GetAllProductsByCategoryId(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if(category != null)
            {
                db.Products.Where(x => x.Category == category).ToList();
                return db.Products;
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

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}