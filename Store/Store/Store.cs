using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Store
    {
        public static string[] ClientDiscount = {
            "DiscountBonusCard",
            "DiscountPercentCard",
            "DiscountAmount"
        };

        public static string[] ClientDiscountDescr = {
            "Бонусная карта",
            "Скидочная карта",
            "Сумма от стоимость"
        };

        public Store()
        {
            if (this.NeedCreateNewProduct())
            {
                Product product = new Product();
            }
            

            
        }

        protected bool NeedCreateNewProduct()
        {
            Console.WriteLine("Создать новый товар?");
            Console.WriteLine("Y или YES");
            string createProduct = Console.ReadLine().ToLower();
            if (createProduct == "y" || createProduct == "yes")
            {
                return true;
            }

            return false;
        }
        
    }
}
