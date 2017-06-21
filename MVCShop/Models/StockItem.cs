using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Quantity { get; set; }

        [Required]
        [StringLength(140)]
        public string ItemDescription { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        [ForeignKey("StockShelf")]
        public int StockShelfID { get; set; }
        public virtual StockShelf StockShelf { get; set; }
    }   
}