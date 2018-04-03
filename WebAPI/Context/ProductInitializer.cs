using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class ProductInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var cat1 = new Category { Name = "Meat" };
            var cat2 = new Category { Name = "Fish" };
            var cat3 = new Category { Name = "Food" };
            var cat4 = new Category { Name = "Drinks" };
            var cat5 = new Category { Name = "Cereals" };

            context.Products.Add(new Product { Id = 1, Name = "Veal", Price = 14, Category = cat1});
            context.Products.Add(new Product { Id = 2, Name = "Fish1", Price = 23, Category = cat2 });
            context.Products.Add(new Product { Id = 3, Name = "Catfish", Price = 45, Category = cat2 });
            context.Products.Add(new Product { Id = 4, Name = "Humburger", Price = 24, Category = cat3 });
            context.Products.Add(new Product { Id = 5, Name = "Bread", Price = 35, Category = cat3 });
            context.Products.Add(new Product { Id = 6, Name = "Juice", Price = 9, Category = cat4 });
            context.Products.Add(new Product { Id = 7, Name = "Cornflakes", Price = 12, Category = cat5 });
            context.Products.Add(new Product { Id = 8, Name = "Buffalo", Price = 34, Category = cat2 });
            context.Products.Add(new Product { Id = 9, Name = "Sweet cereals", Price = 87, Category = cat5 });
            context.Products.Add(new Product { Id = 10, Name = "Bacon", Price = 21, Category = cat1 });

            base.Seed(context);
        }
    }
}