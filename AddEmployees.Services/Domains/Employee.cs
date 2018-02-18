using AddEmployees.Services.Payment.Method;
using EmloyeePayments.Infrastructure.Affiliation;
using EmloyeePayments.Infrastructure.Payment.Classification;
using EmloyeePayments.Infrastructure.Payment.Schedule;
using System;

namespace EmloyeePayments.Infrastructure.Domains
{
    public class Employee
    {
        public int EmpId { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IPaymentClassification Classification { get; set; }
        public IPaymentSchedule Schedule { get; set; }
        public IPaymentMethod Method { get; set; }
        public IAffiliation Affiliation { get; set; }

        public Employee(int empId, string name, string address)
        {
            EmpId = empId;
            Name = name;
            Address = address;
        }

        public bool IsPayDate(DateTime payDate)
        {
            return Schedule.IsPayDate(payDate);
        }

        internal void Payday(PayCheck pc)
        {
            var grossPay = Classification.CalculatePay(pc);
            var deductions = Affiliation.CalculateDeductions(pc);
            var netPay = grossPay - deductions;
            pc.GrossPay = grossPay;
            pc.Deductions = deductions;
            pc.NetPay = netPay;
            Method.Pay(pc);
        }
    }
}