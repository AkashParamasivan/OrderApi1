using OrderApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi1.Repository
{
    public interface IOrderRepo
    {
        Task<Ordertable> PostOrder(Ordertable order);

        Task<Ordertable> DeleteOrder(int id);

        Task<Ordertable> PutOrder(int id, Ordertable item);

        IEnumerable<Ordertable> GetByOrderdate(string date);

        IEnumerable<Ordertable> GetByProductID(int Productid);

        IEnumerable<Ordertable> GetByCustomerID(int Customerid);
    }
}
