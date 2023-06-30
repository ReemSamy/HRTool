using HRTool.BL.Dtos.VacationDto;
using HRTool.DAL;

namespace HRTool.BL
{
    public interface IVacationsManager
    {
        CreateVacationResultDto CreateVacation(CreateVacationDto vacationDto);
        int CalculateDeductedBalance(DateTime startDate, DateTime endDate);
    }
}
