using EmloyeePayments.Infrastructure.Database;
using EmloyeePayments.Infrastructure.Domains;
using System;
using System.Collections;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService.PaymentService
{
    public class PaydayTransaction : ITransaction
    {
        private readonly Hashtable _paychecks = new Hashtable();
        private readonly DateTime _payDate;
        public PaydayTransaction(DateTime PayDate)
        {
            _payDate = PayDate;
        }

        public void Execute()
        {
            ArrayList empIds = PayrollDatabase.GetAllEmployeeIds();

            foreach (int empId in empIds)
            {
                var e = PayrollDatabase.GetEmployee(empId);
                if (e.IsPayDate(_payDate))
                {
                    PayCheck pc = new PayCheck(_payDate);
                    e.Payday(pc);
                    _paychecks[e.EmpId] = pc;
                }
            }
        }

        public PayCheck GetPayCheck(int empId)
        {
            return _paychecks[empId] as PayCheck;
        }
    }
}