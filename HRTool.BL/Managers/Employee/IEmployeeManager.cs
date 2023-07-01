using HRTool.BL.Dtos.EmployeeDto;
using HRTool.DAL;

namespace HRTool.BL
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeesReadDto> GetEmployees();
        RemainingBalanceDto CalculateRemainingBalance(int employeeId);
        
    }
}
