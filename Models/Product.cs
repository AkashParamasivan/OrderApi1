using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApi1.Models
{
    public partial class Product
    {
        public Product()
        {
            Ordertables = new HashSet<Ordertable>();
        }

        public int Pid { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ordertable> Ordertables { get; set; }

        public static implicit operator Product(Ordertable v)
        {
            throw new NotImplementedException();
        }
    }
}
