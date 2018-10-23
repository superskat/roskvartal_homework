﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Store
    {
        protected List<Product> products { get; set; } = new List<Product>();

        public Store()
        {
            this.ShowMenu();
        }

        protected void ShowMenu()
        {
            Console.WriteLine("----------");
            Console.WriteLine("1 - Создать товар");
            Console.WriteLine("2 - Показать товары");
            Console.WriteLine("-----");
            Console.WriteLine("0 - Выход");
            Console.WriteLine("----------");
            int.TryParse(Console.ReadLine(), out int result);

            if (result == 0)
            {
                Environment.Exit(0);
            }

            switch (result)
            {
                case 1:
                    this.CreateProduct();
                    break;
                case 2:
                    this.ShowProducts();
                    break;
            }

            this.ShowMenu();
        }

        protected void CreateProduct()
        {
            products.Add(new Product());

            Console.WriteLine("----------");
            Console.WriteLine("Создать новый товар?");
            Console.WriteLine("-----");
            Console.WriteLine("Y или N");
            Console.WriteLine("----------");

            string createProduct = Console.ReadLine().ToLower();

            if (createProduct == "y" || createProduct == "yes")
            {
                this.CreateProduct();
            }

        }

        protected void ShowProducts()
        {
            if (this.products.Count == 0)
            {
                Console.WriteLine("----------");
                Console.WriteLine("!Список товаров пуст");
                Console.WriteLine("----------");
                return;
            }

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
