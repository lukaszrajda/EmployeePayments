using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Affiliation
{
    public class NoAffiliation : IAffiliation
    {
        public double CalculateDeductions(PayCheck pc)
        {
            return 0.0;
        }
    }
}