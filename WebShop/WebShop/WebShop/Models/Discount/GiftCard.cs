using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Discount
{
    public class GiftCard: DiscountCard
    {
        public decimal balance { get; protected set; }
        public string number { get; protected set; }

        private GiftCard() { }

        public GiftCard(string number, decimal balance, DateTime dateStart, DateTime dateEnd)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Подарочная карта должна иметь номер");
            }

            if (balance <= 0)
            {
                throw new ArgumentException("Балан подарочной карты не может быть нулевым или отрицательным");
            }

            if (dateEnd <= dateStart.AddDays(1))
            {
                throw new ArgumentException("Срок действия подарочной карты должен быть больше 1 дня");
            }

            this.number = number;
            this.balance = balance;
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }

        public override decimal Apply(decimal price)
        {
            if (this.IsExpiration())
            {
                throw new DateExpirationException(this.dateStart, this.dateEnd);
            }

            if (price <= this.balance)
            {
                this.balance -= price;
            }

            return price - this.balance;
        }
    }
}
