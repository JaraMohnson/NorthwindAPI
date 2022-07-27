using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIDesignLab.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesignLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();


        [HttpGet("OrdersByShipperId")]
        public List<Order> OrdersByShipper(int id)
        {
            return northwindContext.Orders.Where(p=>p.ShipVia == id).ToList();
        }

        [HttpGet("OrdersByCustomerId")] 
        public List <Order> OrdersByCustomerId(string id)
        {
            return northwindContext.Orders.Where(p=>p.CustomerId.ToLower() == id.ToLower()).ToList();
        } 


        //use this if a coworker makes you mad, and you want to remove all their orders so they don't get credit.
        [HttpDelete("RemoveEmployeeOrder")] 

        public List <Order> RemoveEmployeeOrders(int empId)
        {
          List<Order> orders = northwindContext.Orders.Where(p=>p.EmployeeId == empId).ToList();
            foreach (Order o in orders)
            {
                northwindContext.Orders.Remove(o);
            }
            northwindContext.SaveChanges();
            return orders;

        }
     
    }
}
