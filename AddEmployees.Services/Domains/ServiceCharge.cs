using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Domains
{
    public class ServiceCharge
    {
        public DateTime Date { get; private set; }
        public double Amount { get; private set; }
        public ServiceCharge(DateTime date, double amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}