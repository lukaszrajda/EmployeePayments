using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Affiliation;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffiliationTransaction(int empId) : base(empId)
        {
        }

        protected override void Change(Employee e)
        {
            RecordMembership(e);
            e.Affiliation = Affiliation;
        }

        protected abstract IAffiliation Affiliation { get; }
        protected abstract void RecordMembership(Employee e);
    }
}