
using System.Collections.Generic;

using MecroECommerce.Orders.Models;

namespace MecroECommerce.Orders.Services
{
    public interface IOrderService
    {
        List<OrderModel> GetOrders();
        OrderModel GetOrderById(int id);

    }
}
