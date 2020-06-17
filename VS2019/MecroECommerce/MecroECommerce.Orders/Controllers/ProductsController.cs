using System.Collections.Generic;
using MecroECommerce.Orders.Models;
using MecroECommerce.Orders.Services;
using Microsoft.AspNetCore.Mvc;


namespace MecroECommerce.Orders.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService OrderService;

        public OrdersController(IOrderService _OrderService)
        {
            this.OrderService = _OrderService;
        }

        [HttpGet]
        [Route("api/Orders")]
        public List<OrderModel> GetOrders()
        {
            return OrderService.GetOrders();
        }

        [HttpGet]
        [Route("api/Orders/{id}")]
        public OrderModel GetOrderById(int id)
        {
            return OrderService.GetOrderById(id);
        }

    }
}
