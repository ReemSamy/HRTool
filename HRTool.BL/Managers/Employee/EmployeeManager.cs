using HRTool.DAL;

namespace HRTool.BL
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _Repo;
        public EmployeeManager(IEmployeeRepo repo)
        {
            _Repo = repo;
        }
        public Employee? GetEmployeeById(int id)
        {
            var employee = _Repo.GetEmployeeById(id);
            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        public bool UpdateEmployee(Employee employee,int newBalance)
        {
            employee.Balance = newBalance;
            _Repo.SaveChanges();
            return true;
        }
    }
}
