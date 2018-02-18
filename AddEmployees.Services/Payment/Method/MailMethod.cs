using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmloyeePayments.Infrastructure.Domains;

namespace AddEmployees.Services.Payment.Method
{
    public class MailMethod : IPaymentMethod
    {
        public void Pay(PayCheck paycheck)
        {
            throw new NotImplementedException();
        }
    }
}