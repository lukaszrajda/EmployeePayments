using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Payment.Classification;
using System;

namespace EmloyeePayments.Infrastructure.Services.TimeCardService
{
    public class TimeCardTransaction : ITransaction
    {
        private readonly DateTime _date;
        private readonly double _hours;
        private readonly int _empId;
        public TimeCardTransaction(DateTime date, double hours, int empId)
        {
            _date = date;
            _hours = hours;
            _empId = empId;
        }
        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(_empId);
            if (e == null)
            {
                throw new InvalidOperationException("Nie ma takiego pracownika.");
            }
            HourlyClassification hc = e.Classification as HourlyClassification;
            if (hc == null)
            {
                throw new InvalidOperationException("Próba dodania karty czasu pracy do pracownika zatrudnionego" +
                    " w systemie innym niż godzinowy.");
            }
            hc.AddTimeCard(new TimeCard(_date, _hours));
        }
    }
}