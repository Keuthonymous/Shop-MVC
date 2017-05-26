using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCShop.Models
{
    public class StockItem
    {
        [Key]
        public int ArticleNumber { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        [Range (0.1,100000)]
        public double Price { get; set; }
        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }

        [Required]
        [StringLength(140)]
        public string Description { get; set; }
    }   
}