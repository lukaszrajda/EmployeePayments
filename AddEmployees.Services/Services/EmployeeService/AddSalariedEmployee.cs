using EmloyeePayments.Infrastructure.Payment.Schedule;
using EmloyeePayments.Infrastructure.Payment.Classification;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        private readonly double _salary;
        public AddSalariedEmployee(int empId, string name, string address, double salary)
            : base(empId,name,address)
        {
            _salary = salary;
        } 

        protected override IPaymentClassification MakeClassification()
        {
            return new SalariedClassification(_salary);
        }

        protected override IPaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}