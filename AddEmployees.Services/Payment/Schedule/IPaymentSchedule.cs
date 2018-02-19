
using System;

namespace EmloyeePayments.Infrastructure.Payment.Schedule
{
    public interface IPaymentSchedule
    {
        bool IsPayDate(DateTime payDate);
        DateTime GetPayScheduleStartDate(DateTime endDate);
    }
}