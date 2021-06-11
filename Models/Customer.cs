using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApi1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Ordertables = new HashSet<Ordertable>();
        }

        public int Custid { get; set; }
        public string CustomerName { get; set; }
        public string Phoneno { get; set; }
        public string Mailid { get; set; }

        public virtual ICollection<Ordertable> Ordertables { get; set; }
    }
}
