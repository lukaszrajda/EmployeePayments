using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Domains
{
    public class SalesReport
    {
        private readonly DateTime _date;
        private readonly double _salesAmount;
        public SalesReport(DateTime date, double salesAmount)
        {
            _date = date;
            _salesAmount = salesAmount;
        }
        public double SalesAmount
        {
            get { return _salesAmount; }
        }
        public DateTime Date
        {
            get { return _date; }
        }
    }
}