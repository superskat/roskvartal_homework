using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Discount
{
    public class DateExpirationException : Exception
    {
        public DateExpirationException(DateTime startDate, DateTime endDate) : base($"Срок действия карты прошел, карта была действительна с {startDate} по {endDate}")
        {
        }
    }
}
