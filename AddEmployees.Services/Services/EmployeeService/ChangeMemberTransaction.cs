using EmloyeePayments.Infrastructure.Affiliation;
using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private readonly int _memberId;
        private readonly double _dues;
        public ChangeMemberTransaction(int empId, int memberId, double dues) : base(empId)
        {
            _memberId = memberId;
            _dues = dues;
        }

        protected override IAffiliation Affiliation 
            => new UnionAffiliation(_memberId, _dues);

        protected override void RecordMembership(Employee e)
        {
            PayrollDatabase.AddUnionMember(_memberId, e);
        }
    }
}