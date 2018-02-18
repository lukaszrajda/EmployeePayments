
using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public class SalariedClassification : IPaymentClassification
    {
        public double Salary { get; private set; }
        public SalariedClassification(double salary)
        {
            Salary = salary;
        }

        public double CalculatePay(PayCheck pc)
        {
            return Salary;
        }
    }
}