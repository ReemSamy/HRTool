using HRTool.BL.Dtos.VacationDto;
using HRTool.DAL;

namespace HRTool.BL
{
    public interface IVacationsManager
    {
        CreateVacationResultDto CreateVacation(CreateVacationDto vacationDto);
        CalculateBalanceDto CalculateDeductedBalance(DateTime startDate, DateTime endDate);
    }
}
