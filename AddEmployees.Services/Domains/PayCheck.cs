
using System;

namespace EmloyeePayments.Infrastructure.Domains
{
    public class PayCheck
    {
        public double GrossPay;
        public double Deductions;
        public double NetPay;
        public DateTime StartDate { get; set; }
        public DateTime PayDate { get; set; }
        public PayCheck(DateTime startDate, DateTime payDate)
        {
            PayDate = payDate;
            StartDate = startDate;
        }

        public string GetField(string v)
        {
            throw new NotImplementedException();
        }
    }
}