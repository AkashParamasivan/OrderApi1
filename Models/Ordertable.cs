using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApi1.Models
{
    public partial class Ordertable
    {
        public int Orderid { get; set; }
        public int? Pid { get; set; }
        public int? Customerid { get; set; }
        public string OrderDate { get; set; }
        public string ListofProducts { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product PidNavigation { get; set; }
    }
}
