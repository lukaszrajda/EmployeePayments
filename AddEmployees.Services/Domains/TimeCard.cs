using System;

namespace EmloyeePayments.Infrastructure.Domains
{
    public class TimeCard
    {
        private readonly DateTime _date;
        private readonly double _hours;
        public TimeCard(DateTime date, double hours)
        {
            _date = date;
            _hours = hours;
        }
        public double Hours
        {
            get { return _hours; }
        }
        public DateTime Date
        {
            get { return _date; }
        }
    }
}