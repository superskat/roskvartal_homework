using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Product
    {
        string name { get; set; }
        float price { get; set; }

        public Product()
        {
            this.Create();
        }

        protected void Create()
        {
            Console.WriteLine("Введите название товара");
            this.name = Console.ReadLine();

            Console.WriteLine("Введите стоимость товара");
            this.price = this.SetProductPrice();
        }

        protected float SetProductPrice()
        {
            float.TryParse(Console.ReadLine(), out float price);

            if (price < 0)
            {
                Console.WriteLine("Введена некорректная стоимость товара, повторите попытку");
                this.SetProductPrice();
            }

            return price;
        }

        public float GetPrice()
        {
            return this.price;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
