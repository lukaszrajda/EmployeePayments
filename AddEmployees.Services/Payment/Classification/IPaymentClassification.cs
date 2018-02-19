
using EmloyeePayments.Infrastructure.Domains;
using System;

namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public interface IPaymentClassification
    {
        double CalculatePay(PayCheck pc);
    }
}