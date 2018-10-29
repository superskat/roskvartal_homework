using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Discount
{
    public class PercentCard : DiscountCard
    {
        public byte percent { get; protected set; }

        public PercentCard(byte percent, DateTime dateStart, DateTime dateEnd)
        {

            if (dateEnd <= dateStart.AddDays(1))
            {
                throw new ArgumentException("Срок действия подарочной карты должен быть больше 1 дня");
            }

            if (percent >= 100 || percent <= 0)
            {
                throw new ArgumentException("Процент скидки не может быть больше либо равен 100% или меньше либо равен 0");
            }

            this.percent = percent;
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }

        public override decimal Apply(decimal price)
        {
            if (this.IsExpiration())
            {
                throw new DateExpirationException(this.dateStart, this.dateEnd);
            }

            return price - ((price * this.percent) / 100);
        }
    }
}
