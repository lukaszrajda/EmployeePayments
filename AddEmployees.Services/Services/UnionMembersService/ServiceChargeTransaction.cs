using EmloyeePayments.Infrastructure.Affiliation;
using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using System;

namespace EmloyeePayments.Infrastructure.Services.UnionMembersService
{
    public class ServiceChargeTransaction : ITransaction
    {
        private readonly int _memberId;
        private readonly DateTime _date;
        private readonly double _charge;
        public ServiceChargeTransaction(int memberId, DateTime date, double charge)
        {
            _memberId = memberId;
            _date = date;
            _charge = charge;
        }
        public void Execute()
        {
            var e = PayrollDatabase.GetUnionMember(_memberId);
            if (e == null)
            {
                throw new InvalidOperationException("Nie ma takiego członka związku.");
            }
            UnionAffiliation ua = null;
            if (e.Affiliation is UnionAffiliation)
                ua = e.Affiliation as UnionAffiliation;
            if (ua == null)
                throw new InvalidOperationException("Próa obciążenia skłądką związkową pracownika, " +
                    "który nie należy do związku zawodowego.");
            ua.AddServiceCharge(new ServiceCharge(_date, _charge));
        }
    }
}