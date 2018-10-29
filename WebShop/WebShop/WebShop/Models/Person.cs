using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public List<Order> orders { get; set; }

        public Person(string name, string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Адрес e-mail не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Номер телефона не может быть пустым");
            }

            this.name = name;
            this.email = email;
            this.phone = phone;
        }
    }
}
