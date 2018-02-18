
using System;

namespace EmloyeePayments.Infrastructure.Payment.Schedule
{
    public class WeeklySchedule : IPaymentSchedule
    {
        public bool IsPayDate(DateTime payDate)
        {
            return IsLastDayOfWeek(payDate);
        }

        private bool IsLastDayOfWeek(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }
    }
}