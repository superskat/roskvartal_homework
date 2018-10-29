using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    abstract public class DiscountBase
    {
        public List<Order> orders { get; set; }

        public abstract decimal Apply(decimal price);
    }
}
