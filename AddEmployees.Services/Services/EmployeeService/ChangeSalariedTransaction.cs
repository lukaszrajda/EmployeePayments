using System;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;


namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private readonly double _salary;

        public ChangeSalariedTransaction(int empId, double salary) : base(empId)
        {
            salary = _salary;
        }

        protected override IPaymentClassification Classification
            => new SalariedClassification(_salary);

        protected override IPaymentSchedule Schedule
            => new MonthlySchedule();
    }
}