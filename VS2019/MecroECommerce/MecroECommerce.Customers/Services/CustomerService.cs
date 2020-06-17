using AutoMapper;
using MecroECommerce.Customers.Models;
using MecroECommerce.Customers.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MecroECommerce.Customers.Services
{
    public class Customerservice : ICustomerservice
    {
        private readonly CustomerDbContext CustomerDbContext;
        private readonly IMapper mapper;
        public Customerservice(CustomerDbContext _CustomerDbContext, IMapper _mapper)
        {
            this.CustomerDbContext = _CustomerDbContext;
            this.mapper = _mapper;
        }
        public List<CustomerModel> GetCustomers()
        {
            return mapper.Map<List<CustomerModel>>(CustomerDbContext.Customers.ToList());
        }

        public CustomerModel GetCustomerById(int id)
        {
            return mapper.Map<CustomerModel>(CustomerDbContext.Customers.FirstOrDefault(x => x.Id == id));
        }

    }
}
