using Microsoft.EntityFrameworkCore;

namespace HRTool.DAL
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly HRContext _Context;
        public EmployeeRepo(HRContext Context)
        {
            _Context = Context;
        }
        public Employee? GetEmployeeById(int id)
        {
            return _Context.Employees
               .Include(e => e.Vacations)
               .FirstOrDefault(t => t.Id == id);
        }
        public void UpdateEmployee(Employee employee)
        {
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _Context.Employees;
        }
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

    }
}
