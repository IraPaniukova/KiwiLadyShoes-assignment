using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KiwiLadyShoes.Models
{
    public partial class Shoe
    {
        public Shoe()
        {
            Sales = new HashSet<Sale>();
        }

        public int ShoeId { get; set; }
        [Display(Name = "Show Name")]  //display names, Ira, 19/10/23
        public string ShoeName { get; set; }
        public decimal Size { get; set; }
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }
        public string Colour { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }

        public int BrandId { get; set; }
        public int TypeId { get; set; }

        public virtual Brand? Brand { get; set; } = null!;
        public virtual Type? Type { get; set; } = null!;
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Wish> Wish { get; set; } = new List<Wish>();
    }
}
