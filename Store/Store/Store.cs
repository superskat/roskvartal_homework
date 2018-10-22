using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Store
    {
        string[] ClientDiscount = {
            "DiscountBonusCard",
            "DiscountPercentCard",
            "DiscountAmount"
        };

        string[] ClientDiscountDescr = {
            "Бонусная карта",
            "Скидочная карта",
            "Сумма от стоимость"
        };

        public Store()
        {
            Product product = new Product();
            dynamic discount = null;

            if (this.NeedCreateNewProduct())
            {
                product.Create();
            }

            if (this.NeedCreateNewDiscount())
            {
                discount = this.CreateNewDiscount();
            }

            if (this.NeedShowDiscountPrice() && product.Isset() && discount != null)
            {
                var discountPrice = this.GetProductDiscountPrice(product.GetPrice(), discount);
                if (discountPrice <= 0)
                {
                    discountPrice = product.GetPrice();
                }

                Console.WriteLine($"Стоимость товара {product.GetName()} с учетом скидки составляет {discountPrice}. Информаци о скидке: {discount.GetInfo()}");
            }
            
        }

        protected bool NeedCreateNewProduct()
        {
            Console.WriteLine("Создать новый товар?");
            Console.WriteLine("1 - Создать товар");
            Console.WriteLine("2 - Не создать товар");

            int.TryParse(Console.ReadLine(), out int result);

            if (result == 1)
            {
                return true;
            }

            return false;
        }

        protected bool NeedCreateNewDiscount()
        {
            Console.WriteLine("Создать новую скидку?");
            Console.WriteLine("1 - Создать скидку");
            Console.WriteLine("2 - Не создать скидку");

            int.TryParse(Console.ReadLine(), out int result);

            if (result == 1)
            {
                return true;
            }

            return false;
        }

        protected dynamic CreateNewDiscount()
        {
            if (this.ClientDiscount.Length != this.ClientDiscountDescr.Length)
            {
                Console.WriteLine("Количество типов скидок не соответствует количеству описаний");
                Console.WriteLine("Нажмите Enter для завершения");
                Console.ReadLine();

                Environment.Exit(0);
            }

            Console.WriteLine("Выберите тип скидки:");

            for (var i = 0; i < this.ClientDiscountDescr.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + this.ClientDiscountDescr[i]);
            }

            int.TryParse(Console.ReadLine(), out int result);

            if (result > this.ClientDiscount.Length || result < 1)
            {
                Console.WriteLine("Недопустимое значение, посторите попытку");
                this.CreateNewDiscount();
            }

            return Activator.CreateInstance(Type.GetType("Store.Discount." + this.ClientDiscount[(result - 1)]));
        }

        protected bool NeedShowDiscountPrice()
        {
            Console.WriteLine("Показать стоимость товара с учетом скидки?");
            Console.WriteLine("1 - Показать");
            Console.WriteLine("2 - Не показывать");

            int.TryParse(Console.ReadLine(), out int result);

            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public float GetProductDiscountPrice(float price, dynamic discount)
        {
            if (!discount.IsDiscountValid())
            {
                Console.WriteLine("Скидка настроенна некорректно");
            }
            else
            {
                if (discount.IsDiscountAvailable())
                {
                    return discount.GetDiscountPrice(price);
                }
                else
                {
                    Console.WriteLine("Скидка недоступна");
                }
            }

            return 0;
        }
    }
}
