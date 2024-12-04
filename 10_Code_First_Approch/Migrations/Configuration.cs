namespace _10_Code_First_Approch.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using  _10_Code_First_Approch.Models;
    using _10_Code_First_Approch.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<_10_Code_First_Approch.Models.Entity.CodeFirstDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_10_Code_First_Approch.Models.Entity.CodeFirstDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.categories.Add(new Category() { Id = 1, Name = "Electronic devices", Rating = 4 });
            context.categories.Add(new Category() { Id = 2, Name = "Wear", Rating = 3 });
            context.categories.Add(new Category() { Id = 3, Name = "Sport", Rating = 5 });
            context.categories.Add(new Category() { Id = 4, Name = "Sjj", Rating = 3 });

            context.products.Add(new Product() { ProductId = 1, Name = "Mobile", Price = 3000, CategoryId = 1 });
        }

    }
}
