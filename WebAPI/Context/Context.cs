using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class Context : DbContext
    {
        public Context() : base("Database")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}