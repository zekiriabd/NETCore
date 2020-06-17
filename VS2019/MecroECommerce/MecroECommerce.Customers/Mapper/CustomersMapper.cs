using MecroECommerce.Customers.Models;
using MecroECommerce.Customers.Persistence;

namespace MecroECommerce.Customers.Mapper
{
    public class CustomersMapper : AutoMapper.Profile
    {
        public CustomersMapper()
        {
            CreateMap<Customer, CustomerModel>();            
        }
    }
}
