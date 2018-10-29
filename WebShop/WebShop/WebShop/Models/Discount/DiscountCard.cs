using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Discount
{
    abstract public class DiscountCard: DiscountBase
    {
        public int id { get; set; }
        public DateTime dateStart { get; protected set; }
        public DateTime dateEnd { get; protected set; }

        protected bool IsExpiration()
        {
            return !(this.dateStart <= DateTime.Now && this.dateEnd >= DateTime.Now);
        }
    }
}
