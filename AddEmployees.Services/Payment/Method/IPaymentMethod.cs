using EmloyeePayments.Infrastructure.Domains;


namespace AddEmployees.Services.Payment.Method
{
    public interface IPaymentMethod
    {
        void Pay(PayCheck paycheck);
    }
}