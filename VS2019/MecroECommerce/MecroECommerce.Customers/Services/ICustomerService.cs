
using System.Collections.Generic;

using MecroECommerce.Customers.Models;

namespace MecroECommerce.Customers.Services
{
    public interface ICustomerservice
    {
        List<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(int id);

    }
}
