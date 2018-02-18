using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Payment.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmloyeePayments.Infrastructure.Services.CommissionService
{
    public class CommissionTransaction : ITransaction
    {
        private readonly DateTime _date;
        private readonly double _sale;
        private readonly int _empId;

        public CommissionTransaction(DateTime date, double sale, int empId)
        {
            _date = date;
            _sale = sale;
            _empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(_empId);
            if (e == null)
            {
                throw new InvalidOperationException("Nie ma takiego pracownika.");
            }
            CommissionedClassification cc = e.Classification as CommissionedClassification;
            if (cc == null)
            {
                throw new InvalidOperationException("Próba dodania karty czasu pracy do pracownika zatrudnionego" +
                    " w systemie innym niż godzinowy.");
            }
            cc.AddSalesReport(new SalesReport(_date, _sale));
        }
    }
}
