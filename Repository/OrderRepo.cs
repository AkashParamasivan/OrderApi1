using OrderApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi1.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly shopContext _context;


        public OrderRepo()
        {

        }
        public OrderRepo(shopContext context)
        {
            _context = context;
        }
        public async Task<Ordertable> DeleteOrder(int id)
        {
            Ordertable sp = await _context.Ordertables.FindAsync(id);
            if (sp == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Remove(sp);
                _context.SaveChanges();
            }
            return sp;
        }

        

        public async Task<Ordertable> PostOrder(Ordertable order)
        {
            await _context.Ordertables.AddAsync(order);
            _context.SaveChanges();
            return order;
        }

        public async Task<Ordertable> PutOrder(int id, Ordertable item)
        {
            Ordertable Sp = await _context.Ordertables.FindAsync(id);
         
            Sp.Pid = item.Pid;
            Sp.Customerid = item.Customerid;
            Sp.OrderDate = item.OrderDate;
            Sp.ListofProducts = item.ListofProducts;
            Sp.TotalAmount = item.TotalAmount;
            _context.SaveChanges();
            return Sp;
        }

        

        public IEnumerable<Ordertable> GetByProductID(int Productid)
        {
            return _context.Ordertables.Where(C => C.Pid == Productid).ToList();
        }

        public IEnumerable<Ordertable> GetByCustomerID(int Customerid)
        {
            return _context.Ordertables.Where(C => C.Customerid == Customerid).ToList();
        }

        public IEnumerable<Ordertable> GetByOrderdate(string date)
        {
            return _context.Ordertables.Where(C => C.OrderDate == date).ToList();
          
        }
    }
}
