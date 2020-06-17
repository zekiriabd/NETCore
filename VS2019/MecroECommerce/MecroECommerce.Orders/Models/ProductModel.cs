using System;

namespace MecroECommerce.Orders.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
