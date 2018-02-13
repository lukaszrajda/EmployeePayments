using EmloyeePayments.Infrastructure.Payment.Schedule;
using EmloyeePayments.Infrastructure.Payment.Classification;
using AddEmployees.Services.Payment.Method;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Database;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public abstract class AddEmployeeTransaction : ITransaction
    {
        private readonly int _empId;
        private readonly string _name;
        private readonly string _address;
        public AddEmployeeTransaction(int empId, string name, string address)
        {
            _empId = empId;
            _name = name;
            _address = address;
        }

        public void Execute()
        {
            IPaymentClassification pc = MakeClassification();
            IPaymentSchedule ps = MakeSchedule();
            IPaymentMethod pm = new HoldMethod();

            Employee e = new Employee(_empId, _name, _address);
            e.Classification = pc;
            e.Schedule = ps;
            e.Method = pm;
            PayrollDatabase.AddEmlpoyee(e.EmpId, e);

        }

        protected abstract IPaymentClassification MakeClassification();
        protected abstract IPaymentSchedule MakeSchedule();
    }
}