using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Context.CategoryRepository
{
    public class CategoryRepository : IDisposable, ICategoryRepository
    {
        private readonly DataContext db;// = new DataContext();
        public CategoryRepository(DataContext context)
        {
            db = context;
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
                    //db = null;
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