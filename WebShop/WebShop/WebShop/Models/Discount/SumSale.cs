using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Discount
{
    public class SumSale : DiscountBase
    {
        public decimal sum { get; private set; }

        public SumSale(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Сумма скидки не может быть отрицательной или нулевой");
            }

            this.sum = sum;
        }

        public override decimal Apply(decimal price)
        {
            if (price <= this.sum)
            {
                throw new ArgumentException("Итоговая сумма не может быть меньше размера скидки");
            }

            return price - this.sum;
        }
    }
}
