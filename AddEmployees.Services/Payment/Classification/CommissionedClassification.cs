using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;
using System.Collections;
using EmloyeePayments.Infrastructure.Extensions;

namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public class CommissionedClassification : IPaymentClassification
    {
        private readonly Hashtable _salesReports = new Hashtable();
        public double Salary { get; private set; }
        public double CommissionRate { get; private set; }
        public CommissionedClassification(double salary, double commissionRate)
        {
            Salary = salary;
            CommissionRate = commissionRate;
        }

        public void AddSalesReport(SalesReport salesReport)
        {
            _salesReports[salesReport.Date] = salesReport;
        }
        public double CalculatePay(PayCheck pc)
        {
            double totalPay = Salary;
            foreach (SalesReport sr in _salesReports.Values)
            {
                if (DateUtils.IsInPayPeriod(sr.Date, pc.StartDate, pc.PayDate))
                {
                    totalPay += CalculatePayForSalesReports(sr);
                }
            }
            return totalPay;
        }

        private double CalculatePayForSalesReports(SalesReport sr)
        {
            return CommissionRate * sr.SalesAmount;
        }

        public SalesReport GetSaleReport(DateTime date)
        {
            return _salesReports[date] as SalesReport;
        }
    }
}