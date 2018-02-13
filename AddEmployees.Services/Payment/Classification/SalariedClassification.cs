
namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public class SalariedClassification : IPaymentClassification
    {
        public double Salary { get; private set; }
        public SalariedClassification(double salary)
        {
            Salary = salary;
        }
    }
}