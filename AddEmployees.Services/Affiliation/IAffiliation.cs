using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Affiliation
{
    public interface IAffiliation
    {
        double CalculateDeductions(PayCheck pc);
    }
}
