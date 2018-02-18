
using EmloyeePayments.Infrastructure.Domains;

namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public interface IPaymentClassification
    {
        double CalculatePay(PayCheck pc);
    }
}