using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class OrderItem
    {
        public int id { get; set; }

        public int productId { get; set; }
        public Product product { get; set; }

        public int orderId { get; set; }
        public Order order { get; set; }

        public int quantity { get; set; }

        private OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
    }
}
