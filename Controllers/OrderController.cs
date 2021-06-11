using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi1.Models;
using OrderApi1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _context;

        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(OrderController));

        public OrderController(IOrderRepo context)
        {
            _context = context;
        }

        [HttpPost("PostOrder")]

        public async Task<IActionResult> PostOrder(Ordertable order)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = await _context.PostOrder(order);
            log.Info("Post Orders Detail method is invoked");
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Ordertable order)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editedOrder = await _context.PutOrder(id, order);
            log.Info(" Order with id " + id + "got updated");
            return Ok(editedOrder);
        }
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedOrder = await _context.DeleteOrder(id);

            log.Info(" Order with id " + id + "got deleted");
            return Ok(deletedOrder);
        }

        [HttpGet("{date}/GetByOrderdate")]
        public IEnumerable<Ordertable> GetOrderDates(string date)
        {
            log.Info("Get Orderlist with date "+date+" got invoked");
            return _context.GetByOrderdate(date);
        }

        [HttpGet("{Productid}/GetByProductID")]
        public IEnumerable<Ordertable> GetByProductID(int Productid)
        {
            log.Info("Get Productlist with Productid " + Productid + " got invoked");
            return _context.GetByProductID(Productid);
        }

        [HttpGet("{Customerid}/GetByCustomerID")]
        public IEnumerable<Ordertable> GetByCustomerID(int Customerid)
        {
            log.Info("Get Productlist with Customerid " + Customerid + " got invoked");
            return _context.GetByCustomerID(Customerid);
        }


        
    }
}
