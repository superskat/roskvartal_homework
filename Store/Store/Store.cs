using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Store
    {

        public Store()
        {
            if (this.NeedCreateNewProduct())
            {
                Product product = new Product();
            }

        }

        protected bool NeedCreateNewProduct()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Создать новый товар?");
            Console.WriteLine("-----");
            Console.WriteLine("Y или YES");
            Console.WriteLine("----------");
            string createProduct = Console.ReadLine().ToLower();
            if (createProduct == "y" || createProduct == "yes")
            {
                return true;
            }

            return false;
        }
        
    }
}
