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

        public object StoreContext { get; internal set; }

        public IEnumerable<StockItem> GetAllItems()
        {
            return context.Items.ToList();
        }

        public void AddNewItem(StockItem item)
        {
            if (CheckShelfPosition(item) == false)
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        public void RemoveItem(StockItem item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public StockItem DetailsByArtNum(int? ArtNum)
        {
            return context.Items.SingleOrDefault(item => item.ArticleNumber == ArtNum);
        }

        public List<StockItem> DeleteMultiple(int id)
        {
            var query = (from i in context.Items
                         where i.ArticleNumber == id
                         select i).ToList();

            return query;
        }

        public IEnumerable<StockItem> SearchByPriceOrName(string searchTerm = null)
        {
            var query = from i in context.Items
                        where searchTerm == null || i.Name.StartsWith(searchTerm)
                        select i;
            return query;
        }

        public void Edit(StockItem item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public bool CheckShelfPosition(StockItem item)
        {
            if (context.Items.Any(i => i.ShelfPosition == item.ShelfPosition))
            {
                return true;
            }
            else return false;
        }

        public void DeleteMultiple(int? id)
        {
            if (id != null)
            {
                var query = (from i in context.Items
                 where i.ArticleNumber == id
                 select i).ToList();

                foreach (var i in query)
                {
                    context.Items.Remove(i);
                }
                context.SaveChanges();  
            }
        }
    }
}