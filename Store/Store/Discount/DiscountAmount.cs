using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Discount
{
    class DiscountAmount : DiscountBase
    {
        protected override void Create()
        {
            Console.WriteLine("Введите сумму скидки");
            this.value = this.SetDiscountValue();
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
                Console.WriteLine("Сумма скидки меньше нуля");
                return false;
            }

            return true;
        }

        public override float GetDiscountPrice(float sourcePrice)
        {
            return sourcePrice - this.value;
        }

        public override bool IsDiscountAvailable()
        {
            if (this.value <= 0)
            {
                Console.WriteLine("Отсутствует сумма скидки");
                return false;
            }

            return true;
        }

        public override bool IsDiscountValid()
        {
            if (this.value > 0)
            {
                return true;
            }

            return false;
        }

        public override string GetInfo()
        {
            return $"Скидка составляет {this.value}р. от стоимости товара";
        }
    }
}
