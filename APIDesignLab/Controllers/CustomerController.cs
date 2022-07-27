using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIDesignLab.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesignLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        //returns the matching customer for any given ID 
        [HttpGet("CustomerByCustomerId")]
        public Customer GetByCustomerId(string id)
        {
            return northwindContext.Customers.FirstOrDefault(x => x.CustomerId == id);
        }


        //returns a list of customers in a given country 
        [HttpGet("CustomersByCountry")]
        public List<Customer> CustomersByCountry(string country)
        {
            return northwindContext.Customers.Where(p => p.Country == country).ToList();
        }

        [HttpPost("NewCustomer")]
        public Customer NewCustomer(string _customerId, string _companyName, string _contactName,
            string _contactTitle, string _address, string _city, string _region, string _postalCode,
            string _country, string _phone, string _fax)
        {
            Customer newCustomer = new Customer()
            {
                CustomerId = _customerId,
                CompanyName = _companyName,
                ContactName = _contactName,
                ContactTitle = _contactTitle,
                Address = _address,
                City = _city,
                Region = _region,
                PostalCode = _postalCode,
                Country = _country,
                Phone = _phone,
                Fax = _fax            
            };
            northwindContext.Customers.Add(newCustomer);    
            //northwindContext.SaveChanges();
            return newCustomer;

        }
    }
}
