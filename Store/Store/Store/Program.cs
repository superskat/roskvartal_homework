using System;
using System.CodeDom.Compiler;
using System.Text;
using System.Xml;

namespace Store
{
    class Program
    {

        static void Main(string[] args)
        {
            new Store();

            Console.WriteLine("Нажмите Enter для завершения");
            Console.ReadLine();
            Environment.Exit(0);
        }
        
    }
}
