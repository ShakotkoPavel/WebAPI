using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Context.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private Context db = new Context();

        public async void AddCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

        public async void Delete(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if(category != null)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories;
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