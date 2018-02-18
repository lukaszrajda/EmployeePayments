
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Services.CommissionService;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using EmloyeePayments.Infrastructure.Services.EmployeeService.PaymentService;
using EmloyeePayments.Infrastructure.Services.TimeCardService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmloyeePayments.Test.PaymentTests
{
    [TestClass]
    public class EmployeePaymentTEsts
    {

        [TestMethod]
        public void PaySingleSalariedEmployeeTest()
        {
            int empId = 1;
            string name = "Bogdan";
            string address = "Home";
            double salary = 1000.0;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, name, address, salary);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 30);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, salary);
        }

        private void ValidatePayCheck(PaydayTransaction pt, int empId, DateTime date, double pay)
        {
            PayCheck pc = pt.GetPayCheck(empId);
            Assert.IsNotNull(pc);
            Assert.AreEqual(date, pc.PayDate);
            Assert.AreEqual(pay, pc.GrossPay, .001);
            Assert.AreEqual(0.0, pc.Deductions, .001);
            Assert.AreEqual(pay, pc.NetPay, .001);
        }

        [TestMethod]
        public void PaySingleHourlyEmployeeWrongDate()
        {
            int empId = 1;
            string name = "Bogdan";
            string address = "Home";
            double hourlyRate = 15.25;
            int hours = 8;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, address, hourlyRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 8);
            TimeCardTransaction tc = new TimeCardTransaction(payDate, hours, empId);
            tc.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            var pc = pt.GetPayCheck(empId);
            Assert.IsNull(pc);
        }

        [TestMethod]
        public void PaySingleHourlyEmployeeOneTimeCard()
        {
            int empId = 2;
            string name = "Bartosz";
            string address = "Home";
            double hourlyRate = 15.25;
            int hours = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, address, hourlyRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // piątek
            TimeCardTransaction tc = new TimeCardTransaction(payDate, hours, empId);
            tc.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, hours * hourlyRate);
        }

        [TestMethod]
        public void PaySingleHourlyEmployeeOvertimeOneTimeCard()
        {
            int empId = 3;
            string name = "Marek";
            string address = "Home";
            double hourlyRate = 15.25;
            int hours = 9;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, address, hourlyRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // piątek
            TimeCardTransaction tc = new TimeCardTransaction(payDate, hours, empId);
            tc.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, (8 + 1.5) * hourlyRate);
        }

        [TestMethod]
        public void PaySingleHourlyEmployeeTwoTimeCards()
        {
            int empId = 3;
            string name = "Marek";
            string address = "Home";
            double hourlyRate = 15.25;
            int hours1 = 2;
            int hours2 = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, address, hourlyRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // piątek
            TimeCardTransaction tc1 = new TimeCardTransaction(payDate, hours1, empId);
            tc1.Execute();
            TimeCardTransaction tc2 = new TimeCardTransaction(payDate.AddDays(-1), hours2, empId);
            tc2.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            var pc = pt.GetPayCheck(empId);
            ValidatePayCheck(pt, empId, payDate, (7) * hourlyRate);
        }

        [TestMethod]
        public void PaySingleHourlyEmployeeWithTimeCardsSpinningTwoPayPeriods()
        {
            int empId = 4;
            string name = "Andrzej";
            string address = "Home";
            double hourlyRate = 15.25;
            int hours1 = 2;
            int hours2 = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, address, hourlyRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // piątek
            TimeCardTransaction tc1 = new TimeCardTransaction(payDate, hours1, empId);
            tc1.Execute();
            TimeCardTransaction tc2 = new TimeCardTransaction(payDate.AddDays(-7), hours2, empId);
            tc2.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, (hours1) * hourlyRate);
        }

        [TestMethod]
        public void PayCommissionEmployeeWithoutSalee()
        {
            int empId = 1;
            string name = "Andrzej";
            string address = "Home";
            double salary = 1000;
            double commissionRate = 0.1;
            int sale1 = 1500;
            int sale2 = 2500;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, name, address, salary, commissionRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // 2 piątek
            CommissionTransaction ct = new CommissionTransaction(payDate, sale1, empId);
            ct.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            PayCheck pc = pt.GetPayCheck(empId);
        }

        [TestMethod]
        public void PayCommissionEmployeeWithSingleSale()
        {
            int empId = 1;
            string name = "Andrzej";
            string address = "Home";
            double salary = 1000;
            double commissionRate = 0.1;
            int sale1 = 1500;
            int sale2 = 2500;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, name, address, salary, commissionRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // 2 piątek
            CommissionTransaction ct = new CommissionTransaction(payDate, sale1, empId);
            ct.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, salary + commissionRate * sale1);
        }

        [TestMethod]
        public void PayCommissionEmployeeWithTwoSales()
        {
            int empId = 1;
            string name = "Andrzej";
            string address = "Home";
            double salary = 1000;
            double commissionRate = 0.1;
            int sale1 = 1500;
            int sale2 = 2500;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, name, address, salary, commissionRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 9); // 2 piątek
            CommissionTransaction ct1 = new CommissionTransaction(payDate, sale1, empId);
            ct1.Execute();
            CommissionTransaction ct2 = new CommissionTransaction(payDate.AddDays(-9), sale2, empId);
            ct2.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, salary + commissionRate * sale1 + commissionRate * sale2);
        }

        [TestMethod]
        public void PayCommissionEmployeeWithSalesSpinningTwoPayPeriods()
        {
            int empId = 1;
            string name = "Andrzej";
            string address = "Home";
            double salary = 1000;
            double commissionRate = 0.1;
            int sale1 = 1500;
            int sale2 = 2500;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, name, address, salary, commissionRate);
            t.Execute();
            DateTime payDate = new DateTime(2001, 11, 23); // 2 piątek
            CommissionTransaction ct1 = new CommissionTransaction(payDate, sale1, empId);
            ct1.Execute();
            CommissionTransaction ct2 = new CommissionTransaction(payDate.AddDays(-17), sale2, empId);
            ct2.Execute();
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            ValidatePayCheck(pt, empId, payDate, salary + commissionRate * sale1);
        }
    }
}
