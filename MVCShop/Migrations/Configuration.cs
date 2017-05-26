namespace MVCShop.Migrations
{
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
                new Models.StockItem { ArticleNumber = 1234, Name = "Monster", Price = 20.99, Quantity = 2, Description = "Energy Drink", ShelfPosition = "A1" },
                new Models.StockItem { ArticleNumber = 1334, Name = "RedBull", Price = 16.99, Quantity = 3, Description = "Energy Drink", ShelfPosition = "A2" },
                new Models.StockItem { ArticleNumber = 1434, Name = "Logitech G502 Proteus Spectrum", Price = 949.99, Quantity = 1, Description = "Computer Mouse", ShelfPosition = "A3" },
                new Models.StockItem { ArticleNumber = 1534, Name = "SteelSeries G6 V2", Price = 599.99, Quantity = 1, Description = "Keyboard", ShelfPosition = "A4" }
                );

            for (int i = 0; i < 1000; i += 1)
            {
                context.Items.AddOrUpdate(
                    item => item.ArticleNumber,
                    new Models.StockItem { Name = i.ToString(), Price = 19.99, Quantity = 1, Description = "Something" }
                    );
            }
        }
    }
}
