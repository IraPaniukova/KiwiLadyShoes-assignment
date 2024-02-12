using System;
using System.Collections.Generic;

namespace KiwiLadyShoes.Models
{
    public partial class Type
    {
        public Type()
        {
            ShoeDescriptions = new HashSet<Shoe>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Shoe> ShoeDescriptions { get; set; }
    }
}
