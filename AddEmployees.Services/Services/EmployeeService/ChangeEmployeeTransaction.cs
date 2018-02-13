using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public abstract class ChangeEmployeeTransaction : ITransaction
    {
        private readonly int _empId;
        public ChangeEmployeeTransaction(int empId)
        {
            _empId = empId;
        }
        public void Execute()
        {
            var e = PayrollDatabase.GetEmployee(_empId);
            if (e != null)
            {
                Change(e);
            }
            else
                throw new InvalidOperationException("Nie ma takiego pracownika.");
        }

        protected abstract void Change(Employee e);
    }
}