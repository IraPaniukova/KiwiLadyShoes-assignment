using System;
using System.Collections.Generic;

namespace KiwiLadyShoes.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Sales = new HashSet<Sale>();
        }

        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string PaymentToken { get; set; } = null!;
        public DateTime PaymentDate { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
