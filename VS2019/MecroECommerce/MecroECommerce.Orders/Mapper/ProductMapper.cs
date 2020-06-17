using MecroECommerce.Orders.Models;
using MecroECommerce.Orders.Persistence;

namespace MecroECommerce.Orders.Mapper
{
    public class OrderMapper : AutoMapper.Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderModel>();            
        }
    }
}
