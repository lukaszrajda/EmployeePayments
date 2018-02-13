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
        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            _serviceChargeList.Add(serviceCharge.Date, serviceCharge);
        }
        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return _serviceChargeList[date] as ServiceCharge;
        }
    }
}