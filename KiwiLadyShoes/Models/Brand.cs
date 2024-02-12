using System;
using System.Collections.Generic;

namespace KiwiLadyShoes.Models
{
    public partial class Brand
    {
        public Brand()
        {
            ShoeDescriptions = new HashSet<Shoe>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;

        public virtual ICollection<Shoe> ShoeDescriptions { get; set; }
    }
}
