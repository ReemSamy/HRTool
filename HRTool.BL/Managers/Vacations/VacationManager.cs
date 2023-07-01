using HRTool.BL.Dtos.VacationDto;
using HRTool.BL.Services;
using HRTool.DAL;
using HRTool.DAL.Repos.VacationRepo;

namespace HRTool.BL
{
    public class VacationManager : IVacationsManager
    {
        private HashSet<DateTime> NationalHolidays = new HashSet<DateTime>();

        private readonly IVacationRepo _vacationRepo;
        private readonly ICalculationServices _calculationServices;

        public VacationManager(IVacationRepo vacationRepo, ICalculationServices calculationServices)
        {
            _vacationRepo = vacationRepo;
            _calculationServices = calculationServices;
        }

        #region Deduct The Balance
        public CalculateBalanceDto CalculateDeductedBalance(DateTime startDate, DateTime endDate)
        {
          var balance=  _calculationServices.CalculateDeductedBalance(startDate, endDate);
            return new CalculateBalanceDto(balance);
        }
        #endregion

        #region Create Vacations
        public CreateVacationResultDto CreateVacation(CreateVacationDto vacationDto)
        {
            var vacations = _vacationRepo.GetEmployeeVacations(vacationDto.EmployeeId);

            var isStartOverlapped = vacations.Any(v => vacationDto.StartDate >= v.StartDate && vacationDto.StartDate <= v.EndDate);
            var isEndOverlapped = vacations.Any(v => vacationDto.EndDate >= v.StartDate && vacationDto.EndDate <= v.EndDate);
            if (isStartOverlapped || isEndOverlapped)
            {
                return new CreateVacationResultDto(false,"Overlapped");
            }
            Vacation vacation = new Vacation
            {
                EmployeeId = vacationDto.EmployeeId,
                StartDate = vacationDto.StartDate,
                EndDate = vacationDto.EndDate,
                VacationType = vacationDto.VacationType,
            };

            _vacationRepo.CreateVacation(vacation);
            _vacationRepo.SaveChanges();

            return new CreateVacationResultDto(true, "Success");
        }
        #endregion
    }
}
