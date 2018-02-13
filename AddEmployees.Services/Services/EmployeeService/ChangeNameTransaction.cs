using System;
using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private readonly string _name;
        public ChangeNameTransaction(int empId, string name) : base(empId)
        {
            _name = name;
        }

        protected override void Change(Employee e)
        {
            e.Name = _name;
        }
    }
}