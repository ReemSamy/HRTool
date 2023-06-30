using HRTool.BL;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationsManager _Vacation;
        private readonly IEmployeeManager _empolyee;
        public VacationController(IVacationsManager Vacation, IEmployeeManager employee)
        {
            _Vacation = Vacation;
            _empolyee = employee;
        }
        [HttpPost]
        public IActionResult CreateVacation(CreateVacationDto vacationDto)
        {
            var vacationRequest = _Vacation.CreateVacation(vacationDto);
            if (vacationRequest == null)
            {
                return BadRequest("Vacation Not Created !");
            }
            return Ok(vacationRequest);
        }
        [HttpPost("calculate-duration")]
        public IActionResult CalculateDuration(CalculateDurationDto durationDto)
        {
            var calculationOfVacation = _Vacation.CalculateDeductedBalance(durationDto.StartDate, durationDto.EndDate);

            return Ok(calculationOfVacation);
        }
    }
}
 