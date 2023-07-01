using HRTool.BL;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationsManager _Vacation;

        public VacationController(IVacationsManager Vacation)
        {
            _Vacation = Vacation;
        }
        #region Create Vacations
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
        #endregion

        #region Calculate Remaining Balance
        [HttpPost("calculate-Balance")]
        public IActionResult CalculateBalance(CalculateDurationDto durationDto)
        {
            var calculationOfVacation = _Vacation.CalculateDeductedBalance(durationDto.StartDate, durationDto.EndDate);

            return Ok(calculationOfVacation);
        }
        #endregion
    }
}
