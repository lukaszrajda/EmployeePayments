using EmloyeePayments.Infrastructure.Database;
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
    }
}
