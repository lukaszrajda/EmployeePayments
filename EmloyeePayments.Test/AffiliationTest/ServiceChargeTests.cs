using EmloyeePayments.Infrastructure.Affiliation;
using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using EmloyeePayments.Infrastructure.Services.UnionMembersService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmloyeePayments.Test.AffiliationTest
{
    [TestClass]
    public class ServiceChargeTests
    {
        [TestMethod]
        public void AddServiceChargeTests()
        {
            int empId = 2;
            var name = "Bartosz";
            var hourlyRate = 15.25;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, "Home", hourlyRate);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            var memberId = 86;
            var dues = 88.12;
            UnionAffiliation af = new UnionAffiliation(memberId, dues);
            e.Affiliation = af;
            var date = new DateTime(2005, 8, 8);
            var charge = 12.95;
            PayrollDatabase.AddUnionMember(memberId, e);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, date, charge);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge(date);
            Assert.IsNotNull(sc);
            Assert.AreEqual(charge, sc.Amount, .001);
        }
    }
}
