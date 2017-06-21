using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCShop.Models
{
    public class StockShelf
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ShelfName { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
    }
}