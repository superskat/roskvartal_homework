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

        protected Discount.DiscountBonusCard discountBonusCard = null;
        protected Discount.DiscountPercentCard discountPercentCard = null;
        protected Discount.DiscountAmount discountAmount = null;

        public Product()
        {
            this.Create();
        }

        protected void Create()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Введите название товара");
            this.SetName();

            Console.WriteLine("-----");
            Console.WriteLine("Введите стоимость товара");
            this.SetPrice();

            Console.WriteLine("-----");
            Console.WriteLine("Введите количество товара");
            this.SetQuantity();


            this.CreateDiscount();
            
            Console.WriteLine("----------");
            Console.WriteLine($"Вы создали новый товар {this.GetName()}");
            Console.WriteLine("----------");
            this.ShowProductInfo();
        }

        public void Edit()
        {
            Console.WriteLine("-----\nРедактировать название?[Y или N]");
            string editName = Console.ReadLine().ToLower();
            if (editName == "y" || editName == "yes")
            {
                Console.WriteLine("Введите название товара");
                this.SetName();
            }

            Console.WriteLine("-----\nРедактировать стоимость?[Y или N]");
            string editPrice = Console.ReadLine().ToLower();
            if (editPrice == "y" || editPrice == "yes")
            {
                Console.WriteLine("Введите стоимость товара");
                this.SetPrice();
            }

            Console.WriteLine("-----\nРедактировать количество?[Y или N]");
            string editQuantity = Console.ReadLine().ToLower();
            if (editQuantity == "y" || editQuantity == "yes")
            {
                Console.WriteLine("Введите количество товара");
                this.SetQuantity();
            }

            this.CreateDiscount();
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
            Console.WriteLine("-----");
            Console.WriteLine("Создать новую "+(this.haveDiscount() ? "или редактировать" : "") +" скидку?");
            Console.WriteLine("Y или N");

            string createDiscount = Console.ReadLine().ToLower();

            if (createDiscount != "y" && createDiscount != "yes")
            {
                return;
            }

            Console.WriteLine("----------");
            Console.WriteLine("Выберите тип скидки:");
            Console.WriteLine("-----");
            Console.WriteLine("1 - Бонусная карта"+(this.discountBonusCard != null ? " [редактировать]" : ""));
            Console.WriteLine("2 - Скидочная процентная карта" + (this.discountPercentCard != null ? " [редактировать]" : ""));
            Console.WriteLine("3 - Фиксированная сумма" + (this.discountAmount != null ? " [редактировать]" : ""));
            Console.WriteLine("-----");
            Console.WriteLine("0 - Выход");
            Console.WriteLine("----------");

            int.TryParse(Console.ReadLine(), out int result);

            if (result == 0)
            {
                return;
            }

            if (result > 3 || result < 1)
            {
                Console.WriteLine("!Ошибка ввода, повторите попытку");
                this.CreateDiscount();
            }

            switch (result)
            {
                case 1:
                    this.discountBonusCard = new Discount.DiscountBonusCard();
                    break;
                case 2:
                    this.discountPercentCard = new Discount.DiscountPercentCard();
                    break;
                case 3:
                    this.discountAmount = new Discount.DiscountAmount();
                    break;
            }

            Console.WriteLine("----------");
            this.CreateDiscount();
        }

        public void ShowProductInfo()
        {
            Console.Write($"Название товара: {this.GetName()}, стоимость: {this.GetPrice()}р., количество: {this.GetQuantity()}\n");

            if (this.discountBonusCard != null)
            {
                Console.WriteLine("-----");
                Console.WriteLine("Бонусная карта:");
                Console.Write(this.discountBonusCard.GetInfo() + ". ");
                Console.Write($"Стоимость товара со скидкой составляет {this.discountBonusCard.GetDiscountPrice(this.GetPrice())}р.\n");
            }
            if (this.discountPercentCard != null)
            {
                Console.WriteLine("-----");
                Console.WriteLine("Скидочная процентная карта:");
                Console.Write(this.discountPercentCard.GetInfo() + ". ");
                Console.Write($"Стоимость товара со скидкой составляет {this.discountPercentCard.GetDiscountPrice(this.GetPrice())}р.\n");
            }
            if (this.discountAmount != null)
            {
                Console.WriteLine("-----");
                Console.WriteLine("Фиксированная скидка:");
                Console.Write(this.discountAmount.GetInfo() + ". ");
                Console.Write($"Стоимость товара со скидкой {this.discountAmount.GetDiscountPrice(this.GetPrice())}р.\n");
            }
            Console.WriteLine("----------");
        }

        protected bool haveDiscount()
        {
            if (this.discountBonusCard != null || this.discountPercentCard != null || this.discountAmount != null)
            {
                return true;
            }
            return false;
        }
    }
}
