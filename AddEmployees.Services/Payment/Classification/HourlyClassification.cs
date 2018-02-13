using EmloyeePayments.Infrastructure.Domains;
using System;
using System.Collections;

namespace EmloyeePayments.Infrastructure.Payment.Classification
{
    public class HourlyClassification : IPaymentClassification
    {
        public double HourlyRate;
        private readonly Hashtable _timeCardsTable = new Hashtable();
        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
        }
        public void AddTimeCard(TimeCard timeCard)
        {
            _timeCardsTable.Add(timeCard.Date,timeCard);
        }
        public TimeCard GetTimeCard(DateTime date)
        {
            return _timeCardsTable[date] as TimeCard;
        }
    }
}