using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Order
    {
        public int id { get; set; }
        public string number { get; set; }
        public int personId { get; set; }
        public Person person { get; set; }
        public List<OrderItem> items { get; set; }
        public byte discountType { get; set; }

        public Order()
        {
            this.number = GenerateNumber();
            this.items = new List<OrderItem>();
        }

        private string GenerateNumber()
        {
            return $"{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
        }
    }
}
