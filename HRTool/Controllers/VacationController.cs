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
        }
        [HttpPost]
        public IActionResult CreateVacation(CreateVacationDto vacationDto)
        {
            var result = _Vacation.CreateVacation(vacationDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("calculate-duration")]
        public IActionResult CalculateDuration(CalculateDurationDto durationDto)
        {
            var calculationOfVacation = _Vacation.CalculateDeductedBalance(durationDto.StartDate, durationDto.EndDate);

            return Ok(calculationOfVacation);
        }
    }
}
 