using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public class CommissionedClassification : IPaymentClassification
    {
        public double Salary { get; private set; }
        public double CommissionRate { get; private set; }
        public CommissionedClassification(double salary, double commissionRate)
        {
            Salary = salary;
            CommissionRate = commissionRate;
        }
    }
}