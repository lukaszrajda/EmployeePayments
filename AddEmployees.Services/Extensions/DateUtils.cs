using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Extensions
{
    public class DateUtils
    {
        public static bool IsInPayPeriod(DateTime date, DateTime startDate, DateTime endDate)
        {
            return date <= endDate && date >= startDate;
        }
    }
}