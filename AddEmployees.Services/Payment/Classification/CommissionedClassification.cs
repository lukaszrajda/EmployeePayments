using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;
using System.Collections;

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
                if (IsInPayPeriod(sr, pc.PayDate))
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

        private bool IsInPayPeriod(SalesReport sr, DateTime payDate)
        {
            var payPeriodEndDate = payDate;
            var payPeriodStartDate = payDate.AddDays(-12);
            return sr.Date <= payPeriodEndDate && sr.Date >= payPeriodStartDate;
        }

        public SalesReport GetSaleReport(DateTime date)
        {
            return _salesReports[date] as SalesReport;
        }
    }
}