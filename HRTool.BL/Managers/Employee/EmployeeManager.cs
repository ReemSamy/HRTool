using HRTool.BL.Services;
using HRTool.DAL;

namespace HRTool.BL
{
    public class EmployeeManager : IEmployeeManager
    {
        private HashSet<DateTime> NationalHolidays = new HashSet<DateTime>();
        private readonly IEmployeeRepo _Repo;
        private readonly ICalculationServices _calculation;

        public EmployeeManager(IEmployeeRepo repo,ICalculationServices calculation)
        {
            _Repo = repo;
            _calculation = calculation;
        }

        public bool CalculateRemainingBalance(int employeeId)
        {
            var employee = _Repo.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return false;
            }
            var toltalDeducted = employee.Vacations.Sum(v => _calculation.CalculateDeductedBalance(v.StartDate, v.EndDate));
            var remaining = employee.Balance - toltalDeducted;
            return true;
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

        public bool UpdateEmployee(Employee employee, int newBalance)
        {
            employee.Balance = newBalance;
            _Repo.SaveChanges();
            return true;
        }
    }
}
