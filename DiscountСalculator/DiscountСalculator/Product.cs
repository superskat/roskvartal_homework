using System;

namespace DiscountСalculator
{
    public class Product : IDiscount
    {
        protected string Name { get; set; }
        protected float Price { get; set; }

        public Product()
        {
            this.SetName();
            this.SetPrice();
        }

        public void SetName()
        {
            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();

            if (name.Length < 1)
            {
                Console.WriteLine("Ошибка, название не может быть пустым");
                this.SetName();
            }

            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetPrice()
        {
            Console.WriteLine("Введите стоимость товара");
            float.TryParse(Console.ReadLine(), out float price);

            if (price <= 0)
            {
                Console.WriteLine("Ошибка, стоимость не может быть пустой или отрицательной");
            }

            this.Price = price;
        }

        public float GetPrice()
        {
            return this.Price;
        }

        public float CalculateDiscountPrice(dynamic discount)
        {
            /*return DiscountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? Price - (Price * DiscountValue / 100)
                : Price;*/

            return 0;
        }

        public string GetSellInformation()
        {
            /*return DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
                ? $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {CalculateDiscountPrice()}р."
                : "В настоящий момент на данный товар нет скидок.";*/

            return "";
        }
    }        
}
