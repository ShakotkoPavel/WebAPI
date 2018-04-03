using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("WebAPI_Db")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> ProductsInCart { get; set; }
    }
}