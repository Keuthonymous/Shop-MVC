using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCShop.Models;

namespace MVCShop.DataAccess
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection") { }

        public DbSet<StockItem> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StockShelf> Shelves { get; set; }
    }
}