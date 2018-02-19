
using System;

namespace EmloyeePayments.Infrastructure.Payment.Schedule
{
    public class WeeklySchedule : IPaymentSchedule
    {
        public DateTime GetPayScheduleStartDate(DateTime endDate)
        {
            return endDate.AddDays(-5);
        }

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