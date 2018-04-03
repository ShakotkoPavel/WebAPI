using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class ProductInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Categories.Add(new Category { Name = "Meat" });
            context.Categories.Add(new Category { Name = "Fish" });
            context.Categories.Add(new Category { Name = "Cereals" });
            context.Categories.Add(new Category { Name = "Food" });
            context.Categories.Add(new Category { Name = "Drinks" });

            base.Seed(context);
        }
    }
}