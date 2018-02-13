using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly double _salary;
        private readonly double _commissionRate;
        public ChangeCommissionedTransaction(int empId, double salary, double commissionRate) : base(empId)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }

        protected override IPaymentClassification Classification
            => new CommissionedClassification(_salary, _commissionRate);

        protected override IPaymentSchedule Schedule
            => new BiweeklySchedule();
    }
}