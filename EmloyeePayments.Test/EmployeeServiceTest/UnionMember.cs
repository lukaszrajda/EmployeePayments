using EmloyeePayments.Infrastructure.Affiliation;
using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using EmloyeePayments.Infrastructure.Services.EmployeeService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmloyeePayments.Test.EmployeeServiceTest
{
    [TestClass]
    public class UnionMember : ChangeEmployeeTestBase
    {
        public Employee PayrolDatabase { get; private set; }

        [TestMethod]
        public void ChangeUnionMemberTest()
        {
            AddHourlyEmployee he = new AddHourlyEmployee(base.EmpId, base.Name, base.Address, base.HourlyRate);
            he.Execute();
            int memberId = 7743;
            double dues = 99.42;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(base.EmpId, memberId, dues);
            cmt.Execute();
            Employee e = PayrollDatabase.GetEmployee(base.EmpId);
            Assert.IsNotNull(e);
            IAffiliation affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffiliation);
            UnionAffiliation uf = affiliation as UnionAffiliation;
            Assert.AreEqual(dues, uf.Dues, .001);
            Employee member = PayrollDatabase.GetUnionMember(memberId);
            Assert.AreEqual(e, member);
        }
    }
}
