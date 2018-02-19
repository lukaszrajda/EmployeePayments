using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Affiliation
{
    public class UnionAffiliation : IAffiliation
    {
        private readonly Hashtable _serviceChargeList = new Hashtable();
        public int MemberId { get; private set; }
        public double Dues { get; private set; }

        public UnionAffiliation(int memberId, double dues)
        {
            MemberId = memberId;
            Dues = dues;
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            _serviceChargeList.Add(serviceCharge.Date, serviceCharge);
        }
        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return _serviceChargeList[date] as ServiceCharge;
        }

        public double CalculateDeductions(PayCheck pc)
        {
            double totalDues = 0;
            int fridaysCount = NumOfFridaysInPayPeriod(pc.StartDate, pc.PayDate);
            return fridaysCount * Dues;
        }

        private int NumOfFridaysInPayPeriod(DateTime payPeriodStart, DateTime payPeriodEnd)
        {
            int fridays = 0;
            for (DateTime day = payPeriodStart; day <= payPeriodEnd; day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Friday)
                    fridays++;
            }
            return fridays;
        }
    }
}