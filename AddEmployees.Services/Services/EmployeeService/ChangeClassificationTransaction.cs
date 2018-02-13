using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(int empId) : base(empId)
        {
        }

         protected override void Change(Employee e)
        {
            e.Classification = Classification;
            e.Schedule = Schedule;
        }

        protected abstract IPaymentClassification Classification { get; }
        protected abstract IPaymentSchedule Schedule { get; }
    }
}