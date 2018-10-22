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
        dynamic discount { get; set; } = null;

        public Product()
        {
            this.Create();
        }

        protected void Create()
        {
            Console.WriteLine("Введите название товара");
            this.SetName();

            Console.WriteLine("Введите стоимость товара");
            this.SetPrice();

            Console.WriteLine("Введите количество товара");
            this.SetQuantity();

            Console.WriteLine("Создать новую скидку?");
            Console.WriteLine("Y или YES");
            string createDiscount = Console.ReadLine().ToLower();
            if (createDiscount == "y" || createDiscount == "yes")
            {
                this.CreateDiscount();
            }

            Console.WriteLine($"Вы создали новый товар {this.GetName()} стоимостью {this.GetPrice()}р., количество товара {this.GetQuantity()}");
            if (this.discount != null)
            {
                Console.WriteLine(this.discount.GetInfo());
                Console.WriteLine($"Стоимость товара со скидкой составляет {this.GetDiscountPrice()}р.");
            }

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

        public string GetName()
        {
            return this.name;
        }

        public void SetName()
        {
            this.name = this.SetProcuctName();
        }

        public float GetPrice()
        {
            return this.price;
        }

        public float GetDiscountPrice()
        {
            if (this.discount != null)
            {
                return this.discount.GetDiscountPrice(this.GetPrice());
            }

            return this.GetPrice();
        }

        public void SetPrice()
        {
            this.price = this.SetProductPrice();
        }

        public float GetQuantity()
        {
            return this.quantity;
        }

        public void SetQuantity()
        {
            this.quantity = this.SetProductQuantity();
        }

        protected void CreateDiscount()
        {
            if (Store.ClientDiscount.Length != Store.ClientDiscountDescr.Length)
            {
                Console.WriteLine("Количество типов скидок не соответствует количеству описаний");
                Console.WriteLine("Нажмите Enter для завершения");
                Console.ReadLine();

                Environment.Exit(0);
            }

            Console.WriteLine("Выберите тип скидки:");

            for (var i = 0; i < Store.ClientDiscountDescr.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + Store.ClientDiscountDescr[i]);
            }

            int.TryParse(Console.ReadLine(), out int result);

            if (result > Store.ClientDiscount.Length || result < 1)
            {
                Console.WriteLine("Недопустимое значение, посторите попытку");
                this.CreateDiscount();
            }

            this.discount = Activator.CreateInstance(Type.GetType("Store.Discount." + Store.ClientDiscount[(result - 1)]));
        }
    }
}
