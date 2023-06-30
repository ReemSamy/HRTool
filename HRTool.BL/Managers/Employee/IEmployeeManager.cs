using HRTool.DAL;

namespace HRTool.BL
{
    public interface IEmployeeManager
    {
        Employee? GetEmployeeById(int id);
        bool CalculateRemainingBalance(int employeeId);
        bool UpdateEmployee(Employee employee,int newBalance);
        
    }
}
