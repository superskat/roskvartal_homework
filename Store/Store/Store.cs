using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Store
    {
        protected List<Product> products { get; set; } = new List<Product>();

        public Store()
        {
            this.CreateProduct();

            this.ShowProducts();
            
        }

        protected void CreateProduct()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Создать новый товар?");
            Console.WriteLine("-----");
            Console.WriteLine("Y или N");
            Console.WriteLine("----------");

            string createProduct = Console.ReadLine().ToLower();

            if (createProduct == "y" || createProduct == "yes")
            {
                products.Add(new Product());

                this.CreateProduct();
            }

        }

        protected void ShowProducts()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Показать список товаров?");
            Console.WriteLine("-----");
            Console.WriteLine("Y или N");
            Console.WriteLine("----------");

            string showProducts = Console.ReadLine().ToLower();

            if (showProducts == "y" || showProducts == "yes")
            {
                int i = 0;
                foreach (var product in this.products)
                {
                    Console.WriteLine("----------");
                    Console.Write($"[{i}] ");
                    product.ShowProductInfo();
                    i++;
                }
            }
        }
    }
}
