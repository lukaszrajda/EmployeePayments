using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmloyeePayments.Test.EmployeeServiceTest
{
    [TestClass]
    public class ChangeEmlopyeeTest : ChangeEmployeeTestBase
    {
        [TestMethod]
        public void TestChangeNameTransaction()
        {
            AddHourlyEmployee t = new AddHourlyEmployee(base.EmpId, base.Name, base.Address, base.HourlyRate);
            t.Execute();
            ChangeNameTransaction cnt = new ChangeNameTransaction(base.EmpId, base.SecondName);
            cnt.Execute();
            var e = PayrollDatabase.GetEmployee(base.EmpId);
            Assert.AreEqual(e.Name, base.SecondName);
        }

        [TestMethod]
        public void TestChangeAddressTransaction()
        {
            AddHourlyEmployee t = new AddHourlyEmployee(base.EmpId, base.Name, base.Address, base.HourlyRate);
            t.Execute();
            ChangeAddressTransaction cat = new ChangeAddressTransaction(base.EmpId, base.SecondAddress);
            cat.Execute();
            var e = PayrollDatabase.GetEmployee(base.EmpId);
            Assert.AreEqual(e.Address, base.SecondAddress);
        }
        [TestMethod]
        public void ChangeSalariedEmployeeIntoHourlyEmployeeTest()
        {
            AddSalariedEmployee se = new AddSalariedEmployee(base.EmpId, base.Name, base.Address, base.Salary);
            se.Execute();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(base.EmpId, base.HourlyRate);
            cht.Execute();
            var e = PayrollDatabase.GetEmployee(base.EmpId);
            Assert.IsTrue(e.Classification is HourlyClassification);
            Assert.IsTrue(e.Schedule is WeeklySchedule);
        }

        [TestMethod]
        public void ChangeSalariedEmployeeIntoCommissionedEmployeeTest()
        {
            AddSalariedEmployee se = new AddSalariedEmployee(base.EmpId, base.Name, base.Address, base.Salary);
            se.Execute();
            ChangeCommissionedTransaction cct = new ChangeCommissionedTransaction(base.EmpId, base.Salary, base.CommissionRate);
            cct.Execute();
            var e = PayrollDatabase.GetEmployee(base.EmpId);
            Assert.IsTrue(e.Classification is CommissionedClassification);
            Assert.IsTrue(e.Schedule is BiweeklySchedule);
        }

        [TestMethod]
        public void ChangeHourlyEmployeeIntoSalariedEmployeeTest()
        {
            AddHourlyEmployee he = new AddHourlyEmployee(base.EmpId, base.Name, base.Address, base.HourlyRate);
            he.Execute();
            ChangeSalariedTransaction cst = new ChangeSalariedTransaction(base.EmpId, base.Salary);
            cst.Execute();
            var e = PayrollDatabase.GetEmployee(base.EmpId);
            Assert.IsTrue(e.Classification is SalariedClassification);
            Assert.IsTrue(e.Schedule is MonthlySchedule);
        }
    }
}
