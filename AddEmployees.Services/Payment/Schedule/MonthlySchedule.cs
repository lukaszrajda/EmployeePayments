using System;

namespace EmloyeePayments.Infrastructure.Payment.Schedule
{
    public class MonthlySchedule : IPaymentSchedule
    {
        public DateTime GetPayScheduleStartDate(DateTime endDate)
        {
            return new DateTime(endDate.Year, endDate.Month, 1);
        }

        public bool IsPayDate(DateTime payDate)
        {
            return IsLastDayOfMonth(payDate);
        }

        private bool IsLastDayOfMonth(DateTime date)
        {
            int m1 = date.Month;
            int m2 = date.AddDays(1).Month;
            return (m1 != m2);
        }
    }
}