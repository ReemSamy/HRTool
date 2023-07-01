namespace HRTool.DAL
{
    public interface IEmployeeRepo
    {
        Employee? GetEmployeeById (int id);
        IEnumerable<Employee> GetEmployees();
        void UpdateEmployee (Employee employee);
        int SaveChanges();
    }
}
