using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Discount
{
    class DiscountBonusCard: DiscountBase
    {
        protected override void Create()
        {
            Console.WriteLine("Текущая дата: " + DateTime.Now);

            Console.WriteLine("----------");
            Console.WriteLine("Введите количество бонусов");
            this.value = this.SetDiscountValue();

            Console.WriteLine("-----");
            Console.WriteLine("Введите дату начала действия карты");
            this.dateStart = this.ReadDate();

            Console.WriteLine("-----");
            Console.WriteLine("Введите дату окончания действия карты");
            this.dateEnd = this.ReadDate();
        }

        protected override float SetDiscountValue()
        {
            var value = this.ReadValue();
            if (!this.CheckDiscountValue(value))
            {
                Console.WriteLine("Введено некорректное значение, повторите попытку");
                this.ReadValue();
            }

            return value;
        }

        protected override bool CheckDiscountValue(float value)
        {
            if (value < 0)
            {
                Console.WriteLine("Количество бонусных баллов меньше нуля");
                return false;
            }

            return true;
        }

        public override bool IsDiscountValid()
        {
            if (this.dateStart < this.dateEnd && this.value >= 0)
            {
                return true;
            }

            return false;
        }

        public override bool IsDiscountAvailable()
        {
            if (this.dateEnd < DateTime.Now)
            {
                Console.WriteLine("Бонусная карта действительна до " + this.dateEnd);
                
                return false;
            }

            if (this.value <= 0)
            {
                Console.WriteLine("На карте нет бонусов для списания");
                return false;
            }

            return true;
        }

        public override float GetDiscountPrice(float sourcePrice)
        {
            var price = sourcePrice - this.value;

            if (price <= 0)
            {
                return sourcePrice;
            }

            return price;
        }

        public override string GetInfo()
        {
            return $"Скидка составляет {this.value}р. от стоимости товара, действительна с {this.dateStart.ToShortDateString()} по {this.dateEnd.ToShortDateString()}";
        }
    }
}
