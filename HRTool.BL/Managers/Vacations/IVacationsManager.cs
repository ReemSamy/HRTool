using HRTool.DAL;

namespace HRTool.BL
{
    public interface IVacationsManager
    {
        Vacation? CreateVacation(CreateVacationDto vacation);
        int CalculateDeductedBalance(DateTime startDate, DateTime endDate);
        bool CalculateRemainingBalance(Employee employee, int duration);
    }
}
