using HRTool.DAL;

namespace HRTool.BL
{
    public interface IEmployeeManager
    {
        Employee? GetEmployeeById(int id);
        bool UpdateEmployee(Employee employee,int newBalance);
        
    }
}
