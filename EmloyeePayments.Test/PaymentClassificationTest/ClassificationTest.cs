using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using EmloyeePayments.Infrastructure.Services.TimeCardService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmloyeePayments.Test.PaymentClassificationTest
{
    [TestClass]
    class ClassificationTest
    {
        [TestMethod]
        public void TestTimeCardTransaction()
        {
            int empId = 5;
            var name = "Łukasz";
            var hourlyRate = 15.25;
            var date = new DateTime(2005, 7, 31);
            var hours = 8.0;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, "Home", hourlyRate);
            t.Execute();

            TimeCardTransaction tct = new TimeCardTransaction(date, hours, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            IPaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;

            TimeCard tc = hc.GetTimeCard(date);
            Assert.IsNotNull(tc);
            Assert.AreEqual(hours, tc.Hours);
        }
    }
}
