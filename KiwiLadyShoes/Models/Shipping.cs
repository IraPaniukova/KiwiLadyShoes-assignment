using System;
using System.Collections.Generic;

namespace KiwiLadyShoes.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Sales = new HashSet<Sale>();
        }

        public int ShippingId { get; set; }
        public string Address { get; set; } = null!;
        public decimal ShippingPrice { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
