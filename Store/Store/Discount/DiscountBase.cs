using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Discount
{
    abstract class DiscountBase
    {
        protected DateTime dateStart = new DateTime(1970, 01, 01);
        protected DateTime dateEnd = new DateTime(1979, 01, 01);

        protected float value { get; set;}

        public DiscountBase()
        {
            this.Create();
        }

        abstract protected float SetDiscountValue();

        abstract protected bool CheckDiscountValue(float value);

        abstract protected void Create();

        abstract public bool IsDiscountValid();

        abstract public bool IsDiscountAvailable();

        abstract public float GetDiscountPrice(float sourcePrice);

        protected float ReadValue()
        {
            Console.WriteLine("Формат ввода x,x");

            float.TryParse(Console.ReadLine(), out float result);

            return result;
        }
       
        protected DateTime ReadDate()
        {
            Console.WriteLine("Формат даты dd.mm.yyyy");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                Console.WriteLine("Введено некорректное значение, повторите попытку");
                this.ReadDate();
            }

            return result;
        }
    }
}
