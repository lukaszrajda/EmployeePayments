
using System;

namespace EmloyeePayments.Infrastructure.Domains
{
    public class PayCheck
    {
        public double GrossPay;
        public double Deductions;
        public double NetPay;
        public DateTime PayDate { get; set; }
        public PayCheck(DateTime payDate)
        {
            PayDate = payDate;
        }

        public string GetField(string v)
        {
            throw new NotImplementedException();
        }
    }
}