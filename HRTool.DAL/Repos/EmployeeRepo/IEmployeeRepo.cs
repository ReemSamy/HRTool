namespace HRTool.DAL
{
    public interface IEmployeeRepo
    {
        Employee? GetEmployeeById (int id);
        void UpdateEmployee (Employee employee);
        int SaveChanges();
    }
}
