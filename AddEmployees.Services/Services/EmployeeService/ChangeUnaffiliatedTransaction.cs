using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Affiliation;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Database;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
    {
        public ChangeUnaffiliatedTransaction(int empId) : base(empId)
        {
        }

        protected override IAffiliation Affiliation 
            => new NoAffiliation();

        protected override void RecordMembership(Employee e)
        {
            var affiliation = e.Affiliation;
            if (affiliation is UnionAffiliation)
            {
                var ua = affiliation as UnionAffiliation;
                PayrollDatabase.RemoveUnionMember(ua.MemberId);
            }
        }
    }
}