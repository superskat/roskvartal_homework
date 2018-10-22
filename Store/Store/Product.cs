using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Product
    {
        string name { get; set; }
        float price { get; set; }
        float quantity { get; set; }

        public Product()
        {
            this.Create();
        }

        protected void Create()
        {
            Console.WriteLine("Введите название товара");
            this.name = this.SetProcuctName();

            Console.WriteLine("Введите стоимость товара");
            this.SetPrice();

            Console.WriteLine("Введите количество товара");
            this.SetQuantity();
        }

        protected string SetProcuctName()
        {
            string name = Console.ReadLine();

            if (name.Length < 1)
            {
                this.SetProcuctName();
            }

            return name;
        }

        protected float SetProductPrice()
        {
            float.TryParse(Console.ReadLine(), out float price);

            if (price <= 0)
            {
                Console.WriteLine("Введена некорректная стоимость товара, повторите попытку");
                this.SetProductPrice();
            }

            return price;
        }

        protected float SetProductQuantity()
        {
            float.TryParse(Console.ReadLine(), out float result);

            if (result <= 0)
            {
                Console.WriteLine("Введено некорректное количество товара, повторите попытку");
                this.SetProductQuantity();
            }

            return result;

        }

        public float GetPrice()
        {
            return this.price;
        }

        public void SetPrice()
        {
            this.price = this.SetProductPrice();
        }

        public string GetName()
        {
            return this.name;
        }

        public float GetQuantity()
        {
            return this.quantity;
        }

        public void SetQuantity()
        {
            this.quantity = this.SetProductQuantity();
        }
    }
}
