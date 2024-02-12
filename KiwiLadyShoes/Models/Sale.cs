using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KiwiLadyShoes.Models
{
    // Added the Sales Model Victor, 23/10/23
    public partial class Sale
    {
        public int SaleId { get; set; }
        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; } = null!;
        public int ShoeId { get; set; }
        public int PaymentId { get; set; }
        public int ShippingId { get; set; }

        public virtual Payment Payment { get; set; } = null!;
        public virtual Shipping Shipping { get; set; } = null!;
        public virtual Shoe Shoe { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
