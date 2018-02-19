using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using EmloyeePayments.Infrastructure.Services.EmployeeService.PaymentService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmloyeePayments.Test.AffiliationTest
{
    [TestClass]
    public class AffiliationServiceTests
    {
        [TestMethod]
        public void SalariedUnionMemberDuesTest()
        {
            var empId = 1;
            var name = "Bogdan";
            var address = "Home";
            var salary = 1000.0;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, name, address, salary);
            t.Execute();
            var memberId = 7734;
            var dues = 9.42;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memberId, dues);
            cmt.Execute();
            var payDate = new DateTime(2001, 11, 30);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();
            PayCheck pc = pt.GetPayCheck(empId);
            Assert.IsNotNull(pc);
            Assert.AreEqual(payDate, pc.PayDate);
            Assert.AreEqual(salary, pc.GrossPay, .001);
            Assert.AreEqual(5*dues, pc.Deductions, .001);
            Assert.AreEqual(salary - (5*dues), pc.NetPay, .001);
        }
    }
}
