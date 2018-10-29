using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public List<OrderItem> orderItems { get; set; }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Продукт не может существовать без имени");
            }
            if (price <= 0)
            {
                throw new ArgumentException("Продукт не может быть с отрицательной или нулевой ценой");
            }

            this.name = name;
            this.price = price;
        }
    }
}
