using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIDesignLab.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesignLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        public NorthwindContext northwindContext = new NorthwindContext();


        [HttpGet("GetShipperName")]
        public Shipper CarrierNameByShipperId(int id)
        {
            return northwindContext.Shippers.FirstOrDefault(s => s.ShipperId == id);

        }

        [HttpGet("GetAllShippers")]
        public List<Shipper> GetAll()
        {
            return northwindContext.Shippers.ToList();
        }


        [HttpPost("AddAShipper")] 
        public Shipper AddShipper(int _shipperId, string _companyName, string _phone)
        {
            Shipper newGuy = new Shipper()
            {
                ShipperId = _shipperId,
                CompanyName = _companyName,
                Phone = _phone
            };

            northwindContext.Shippers.Add(newGuy);
            northwindContext.SaveChanges();
            return newGuy;
        }
            

    }
}
