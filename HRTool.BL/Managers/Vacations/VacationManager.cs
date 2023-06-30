using HRTool.DAL;
using HRTool.DAL.Repos.VacationRepo;

namespace HRTool.BL
{
    public class VacationManager : IVacationsManager
    {
        private readonly IVacationRepo _vacationRepo;
        public VacationManager(IVacationRepo vacationRepo)
        {
            _vacationRepo = vacationRepo;
        }
        public int CalculateDeductedBalance(DateTime startDate, DateTime endDate)
        {
            int totalDays = (int)(endDate - startDate).TotalDays;
            int workingDays = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    workingDays++;
            }

            return workingDays;
        }

        public Vacation CreateVacation(CreateVacationDto vacationDto)
        {
            Vacation vacation = new Vacation
            {
                EmployeeId = vacationDto.EmployeeId,
                StartDate = vacationDto.StartDate,
                EndDate = vacationDto.EndDate,
                VacationType = vacationDto.VacationType,
            };

            _vacationRepo.CreateVacation(vacation);
            _vacationRepo.SaveChanges();

            return vacation;
        }


        public bool DeductFromBalance(Employee employee, int duration)
        {
            if (employee.Balance >= duration)
            {
                employee.Balance -= duration;
                _vacationRepo.SaveChanges();
            }
            return true;
        }

        public bool SubmitVacation(Vacation vacation)
        {
            _vacationRepo.SubmitVacation(vacation);
             _vacationRepo.SaveChanges();
            return true;
        }

        
    }
}
