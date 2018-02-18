using EmloyeePayments.Infrastructure.Domains;
using System.Collections;


namespace EmloyeePayments.Infrastructure.Database
{
    public class PayrollDatabase
    {
        private static Hashtable _emloyees = new Hashtable();
        private static Hashtable _unionMembers = new Hashtable();
        public static void AddEmlpoyee(int empId, Employee employee)
        {
            _emloyees[empId] = employee;
        }

        public static void DeleteEmlpoyee(int empId)
        {
            _emloyees[empId] = null;
        }

        public static Employee GetEmployee(int empId)
        {
            return _emloyees[empId] as Employee;
        }

        public static void AddUnionMember(int memberId, Employee employee)
        {
            _unionMembers.Add(memberId, employee);
        }

        public static void RemoveUnionMember(int memberId)
        {
            _unionMembers[memberId] = null;
        }

        public static Employee GetUnionMember(int memberId)
        {
            return _unionMembers[memberId] as Employee;
        }
    }
}