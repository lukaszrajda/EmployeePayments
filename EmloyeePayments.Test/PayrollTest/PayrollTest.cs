using AddEmployees.Services.Payment.Method;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using EmloyeePayments.Infrastructure.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmloyeePayments.Test.PayrollTest
{

    [TestClass]
    public class PayrollTest
    {
        [TestMethod]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            string name = "Bogdan";
            double salary = 1000.0;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, name, "Home", salary);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(name, e.Name);

            IPaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(salary, sc.Salary, .001);
            IPaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);

            IPaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
        [TestMethod]
        public void TestAddCommissionedEmployee()
        {
            int empId = 2;
            string name = "Tadeusz";
            double salary = 1000.0;
            double commissionedRate = 5.0;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, name, "Home", salary, commissionedRate);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(name, e.Name);

            IPaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            CommissionedClassification cc = pc as CommissionedClassification;
            Assert.AreEqual(salary, cc.Salary, .001);
            Assert.AreEqual(commissionedRate, cc.CommissionRate, .001);
            IPaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);

            IPaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void TestAddHourlyEmployee()
        {
            int empId = 3;
            string name = "Tomasz";
            double hourlyRate = 20.0;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, name, "Home", hourlyRate);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(name, e.Name);

            IPaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(hourlyRate, hc.HourlyRate, .001);
            IPaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);

            IPaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
        [TestMethod]
        public void TestDeleteEmployee()
        {
            int empId = 4;
            string name = "Bartosz";
            double salary = 2000.0;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, name, "Home", salary);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();
            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }
    }
}
