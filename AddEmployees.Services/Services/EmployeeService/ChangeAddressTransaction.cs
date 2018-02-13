using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private readonly string _address;
        public ChangeAddressTransaction(int empId, string address)
            : base(empId)
        {
            _address = address;
        }
        protected override void Change(Employee e)
        {
            e.Address = _address;
        }
    }
}