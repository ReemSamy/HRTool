using HRTool.BL.Dtos.EmployeeDto;
using HRTool.BL.Services;
using HRTool.DAL;

namespace HRTool.BL
{
    public class EmployeeManager : IEmployeeManager
    {
        private HashSet<DateTime> NationalHolidays = new HashSet<DateTime>();
        private readonly IEmployeeRepo _Repo;
        private readonly ICalculationServices _calculation;

        public EmployeeManager(IEmployeeRepo repo, ICalculationServices calculation)
        {
            _Repo = repo;
            _calculation = calculation;
        }

        public RemainingBalanceDto CalculateRemainingBalance(int employeeId)
        {
            var employee = _Repo.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return new RemainingBalanceDto(0, 0);
            }

            var toltalDeductedFromAnnual = employee.Vacations
                .Where(v => v.VacationType == VacationType.Annual)
                .Sum(v => _calculation.CalculateDeductedBalance(v.StartDate, v.EndDate));
            var Annualremaining = employee.AnnualBalance - toltalDeductedFromAnnual;
            var toltalDeductedFromSick = employee.Vacations
               .Where(v => v.VacationType == VacationType.Sick)
               .Sum(v => _calculation.CalculateDeductedBalance(v.StartDate, v.EndDate));

            var Sickremaining = employee.SickBalance - toltalDeductedFromSick;


            return new RemainingBalanceDto(Annualremaining, Sickremaining);
        }


        public IEnumerable<EmployeesReadDto> GetEmployees()
        {
            return _Repo.GetEmployees().Select(e => new EmployeesReadDto
            {
                Id = e.Id,
                Name = e.Name,
            });
        }
    }
}
