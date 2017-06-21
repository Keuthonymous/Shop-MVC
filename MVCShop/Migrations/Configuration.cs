namespace MVCShop.Migrations
{
    using MVCShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCShop.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCShop.DataAccess.StoreContext context)
        {
            context.Items.AddOrUpdate(
                i => i.ArticleNumber,
                new StockItem { ArticleNumber = 1234, Name = "Monster", Price = 20.99, Quantity = 2 },
                new StockItem { ArticleNumber = 1334, Name = "RedBull", Price = 16.99, Quantity = 3 },
                new StockItem { ArticleNumber = 1434, Name = "Logitech G502 Proteus Spectrum", Price = 949.99, Quantity = 1 },
                new StockItem { ArticleNumber = 1534, Name = "SteelSeries G6 V2", Price = 599.99, Quantity = 1 }
                );

            context.Categories.AddOrUpdate(
                c => c.ID,
                new Category { Name = "Food", IsAgeRestricted = false, CatDescription = "This is food" },
                new Category { Name = "Alcohol", IsAgeRestricted = true, CatDescription = "This is booze" },
                new Category { Name = "Electronics", IsAgeRestricted = false, CatDescription = "These are fun things" }
                );

            context.Shelves.AddOrUpdate(
                s => s.ID,
                new StockShelf { ShelfName = "A1" },
                new StockShelf { ShelfName = "A2" },
                new StockShelf { ShelfName = "A3" }
                );
        }
    }
}
