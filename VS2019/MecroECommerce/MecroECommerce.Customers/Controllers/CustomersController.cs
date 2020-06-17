using System.Collections.Generic;
using MecroECommerce.Customers.Models;
using MecroECommerce.Customers.Services;
using Microsoft.AspNetCore.Mvc;


namespace MecroECommerce.Customers.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerservice Customerservice;

        public CustomersController(ICustomerservice _Customerservice)
        {
            this.Customerservice = _Customerservice;
        }

        [HttpGet]
        [Route("api/Customers")]
        public List<CustomerModel> GetCustomers()
        {
            return Customerservice.GetCustomers();
        }

        [HttpGet]
        [Route("api/Customers/{id}")]
        public CustomerModel GetCustomerById(int id)
        {
            return Customerservice.GetCustomerById(id);
        }

    }
}
