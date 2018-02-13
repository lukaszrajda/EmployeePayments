using EmloyeePayments.Infrastructure.Database;

namespace EmloyeePayments.Infrastructure.Services.EmployeeService
{
    public class DeleteEmployeeTransaction : ITransaction
    {
        private readonly int _empId;
        public DeleteEmployeeTransaction(int empId)
        {
            _empId = empId;
        }

        public void Execute()
        {
            PayrollDatabase.DeleteEmlpoyee(_empId);
        }
    }
}