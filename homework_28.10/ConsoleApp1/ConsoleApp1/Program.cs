using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum sex : byte
    {
        Male = 1,
        Female = 2
    }

    class Program
    {
        static void Main(string[] args)
        {

            var persons = new List<Person>{
                new Person("Иван", 31, (byte)sex.Male, 400),
                new Person("Женя", 24, (byte)sex.Male, 2100),
                new Person("Даша", 22, (byte)sex.Female, 570),
                new Person("Леша", 25, (byte)sex.Male, 14758),
                new Person("Соня", 27, (byte)sex.Female, 4792)
            };

            //older
            Console.WriteLine(persons.OrderByDescending(x => x.age).First().ToString());
            Console.WriteLine("=====");
            //rich
            Console.WriteLine(persons.OrderByDescending(x => x.balance).First().ToString());
            Console.WriteLine("=====");
            //older and rich

            //2.Определить, сколько людей имеют баланс выше 4000 рублей
            Console.WriteLine(persons.Where(x => x.balance > 4000).Count());
            Console.WriteLine("=====");
            //3.Отсортировать по возрасту, по полу, по балансу
            var ageSort = persons.OrderByDescending(x => x.age);
            foreach(var person in ageSort)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("=====");
            var sexSort = persons.OrderBy(x => x.sex);
            foreach (var person in sexSort)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("=====");
            var balanceSort = persons.OrderBy(x => x.balance);
            foreach (var person in balanceSort)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("=====");
            Console.ReadKey();
        }
    }

    class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public byte sex { get; set; }
        public float balance { get; set; }
        public Person(string name, int age, byte sex, float balance)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.balance = balance;
        }

        public override string ToString()
        {
            return $"{this.name}, {this.age}, {this.balance}";
        }
    }
}
