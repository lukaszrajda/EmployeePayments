using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
        private readonly double _salary;
        private readonly double _commissionRate;
        public AddCommissionedEmployee(int empId, string name, string address, double salary, double commissionRate)
            : base(empId, name, address)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }

        protected override IPaymentClassification MakeClassification()
        {
            return new CommissionedClassification(_salary, _commissionRate);
        }

        protected override IPaymentSchedule MakeSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}