using MVCShop.DataAccess;
using MVCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShop.Repositories
{
    public class ItemRepository
    {
        StoreContext context = new StoreContext();

        public IEnumerable<StockItem> GetAllItems()
        {
            return context.Items.ToList();
        }

        public void AddNewItem(StockItem item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void RemoveItem(StockItem item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public StockItem SearchItemsByArtNum(int ArtNum)
        {
            return context.Items.SingleOrDefault(item => item.ArticleNumber == ArtNum);
        }

        public IEnumerable<StockItem> SearchByPriceOrName(double price, string name)
        {
            var query = from item in context.Items
                        where item.Price == price || item.Name == name
                        select item;
            return query;
        }
    }
}