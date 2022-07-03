using Microsoft.AspNetCore.Mvc;

namespace InventryManager.API.Models
{
    public class OrderModel : RequestModel
    {
        public Guid Id { get; }
        public string OrderNumber { get; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemModel> OrderItems { get; set; }

    }

    public class OrderItemModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
