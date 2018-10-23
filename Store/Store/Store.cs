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

            Console.WriteLine("----------");
            Console.WriteLine("Показать список товаров?");
            Console.WriteLine("-----");
            Console.WriteLine("Y или YES");
            Console.WriteLine("----------");
            string showProducts = Console.ReadLine().ToLower();
            if (showProducts == "y" || showProducts == "yes")
            {
                this.ShowProducts();
            }
        }

        protected void CreateProduct()
        {
            if (this.NeedCreateNewProduct())
            {
                products.Add(new Product());

                this.CreateProduct();
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

        protected void ShowProducts()
        {
            foreach (var product in this.products)
            {
                product.ShowProductInfo();
            }
        }
    }
}
