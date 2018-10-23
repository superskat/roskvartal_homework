using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Discount
{
    class DiscountPercentCard : DiscountBase
    {
        protected override void Create()
        {
            Console.WriteLine("Текущая дата: " + DateTime.Now);
            Console.WriteLine("----------");
            Console.WriteLine("Введите процент скидки");
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
            if (value > 100)
            {
                Console.WriteLine("Процент скидки больше 100");
                return false;
            }

            if (value < 0)
            {
                Console.WriteLine("Процент скидки меньше 0");
                return false;
            }

             return true;
        }

        public override float GetDiscountPrice(float sourcePrice)
        {
            return (float)Math.Round((double)(sourcePrice - (sourcePrice * this.value / 100)), 2);
        }

        public override bool IsDiscountAvailable()
        {
            if (this.dateEnd < DateTime.Now)
            {
                Console.WriteLine("Скидочная карта действительна до " + this.dateEnd);

                return false;
            }

            return true;
        }

        public override bool IsDiscountValid()
        {
            if (this.dateStart < this.dateEnd && (this.value <= 100 && this.value > 0))
            {
                return true;
            }

            return true;
        }

        public override string GetInfo()
        {
            return $"Скидка составляет {this.value}% от стоимости товара, действительна с {this.dateStart.ToShortDateString()} по {this.dateEnd.ToShortDateString()}";
        }
    }
}
