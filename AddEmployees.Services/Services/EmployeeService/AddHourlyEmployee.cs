using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private readonly double _hourlyRate;
        public AddHourlyEmployee(int empId, string name, string address, double hourlyRate)
            : base (empId, name, address)
        {
            _hourlyRate = hourlyRate;
        }

        protected override IPaymentClassification MakeClassification()
        {
            return new HourlyClassification(_hourlyRate);
        }

        protected override IPaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }
    }
}