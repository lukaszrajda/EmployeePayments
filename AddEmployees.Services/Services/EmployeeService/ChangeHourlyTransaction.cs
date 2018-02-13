using System;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly double _hourlyRate;
        public ChangeHourlyTransaction(int empId, double hourlyRate) : base(empId)
        {
            _hourlyRate = hourlyRate;
        }

        protected override IPaymentClassification Classification
            => new HourlyClassification(_hourlyRate);

        protected override IPaymentSchedule Schedule
            => new WeeklySchedule();
    }
}