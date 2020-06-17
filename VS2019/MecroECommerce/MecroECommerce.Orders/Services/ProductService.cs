using AutoMapper;
using MecroECommerce.Orders.Models;
using MecroECommerce.Orders.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MecroECommerce.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext OrderDbContext;
        private readonly IMapper mapper;
        public OrderService(OrderDbContext _OrderDbContext, IMapper _mapper)
        {
            this.OrderDbContext = _OrderDbContext;
            this.mapper = _mapper;
        }
        public List<OrderModel> GetOrders()
        {
            return mapper.Map<List<OrderModel>>(OrderDbContext.Orders.ToList());
        }

        public OrderModel GetOrderById(int id)
        {
            return mapper.Map<OrderModel>(OrderDbContext.Orders.FirstOrDefault(x => x.Id == id));
        }

    }
}
