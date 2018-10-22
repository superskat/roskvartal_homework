using System;
using System.CodeDom.Compiler;
using System.Text;
using System.Xml;

namespace Store
{
    class Program
    {
        static string[] ClientDiscount = {
            "DiscountBonusCard",
            "DiscountPercentCard",
            "DiscountAmount"
        };

        static string[] ClientDiscountDescr = {
            "Бонусная карта",
            "Скидочная карта",
            "Сумма от стоимость"
        };

        static void Main(string[] args)
        {
            if (ClientDiscount.Length != ClientDiscountDescr.Length)
            {
                Console.WriteLine("Количество типов скидок не соответствует количеству описаний");
                Console.WriteLine("Нажмите Enter для завершения");
                Console.ReadLine();

                Environment.Exit(0);
            }

            var product = new Product();
            var discountType = SelectClientDiscount();

            dynamic currentDiscount = Activator.CreateInstance(Type.GetType("Store.Discount." + discountType));

            if (!currentDiscount.IsDiscountValid())
            {
                Console.WriteLine("Скидка настроенна некорректно");
            }
            else
            {
                if (currentDiscount.IsDiscountAvailable())
                {
                    Console.WriteLine($"Стоимость товара {product.GetName()} с учетом скидки составляет {currentDiscount.GetDiscountPrice(product.GetPrice())}");
                }
                else
                {
                    Console.WriteLine("Скидка недоступна");
                }
            }

            Console.WriteLine("Нажмите Enter для завершения");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static string SelectClientDiscount()
        {
            Console.WriteLine("Выберите тип скидки:");

            for (var i = 0; i < ClientDiscountDescr.Length; i++)
            {
                Console.WriteLine((i+1) + " - "+ ClientDiscountDescr[i]);
            }

            int.TryParse(Console.ReadLine(), out int result);

            if (result > ClientDiscount.Length || result < 1)
            {
                Console.WriteLine("Недопустимое значение, посторите попытку");
                SelectClientDiscount();
            }

            return ClientDiscount[(result - 1)];
        }
    }
}
