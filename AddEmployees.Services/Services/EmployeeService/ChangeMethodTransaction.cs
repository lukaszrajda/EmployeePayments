using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;
using AddEmployees.Services.Payment.Method;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangeMethodTransaction(int empId) : base(empId)
        {
        }

        protected override void Change(Employee e)
        {
            e.Method = Method;
        }

        protected abstract IPaymentMethod Method { get; }
    }
}