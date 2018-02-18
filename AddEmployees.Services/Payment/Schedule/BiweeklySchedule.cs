
using System;

namespace EmloyeePayments.Infrastructure.Payment.Schedule
{
    public class BiweeklySchedule : IPaymentSchedule
    {
        public bool IsPayDate(DateTime payDate)
        {
            return IsSecodnOrFourthFridayOfMonth(payDate);
        }

        private bool IsSecodnOrFourthFridayOfMonth(DateTime date)
        {
            var tempDate = new DateTime();
            //find first friday
            for (var i = 1; i <= 7; i++)
            {
                tempDate = new DateTime(date.Year, date.Month, i);
                if (tempDate.DayOfWeek == DayOfWeek.Friday)
                    break;
            }
            return date == tempDate.AddDays(7) || date == tempDate.AddDays(21);
        }
    }
}