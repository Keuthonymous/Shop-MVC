using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCShop.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public bool IsAgeRestricted { get; set; }

        public string CatDescription { get; set; }

        public virtual ICollection<StockItem> StockItems { get; set; }
    }
}