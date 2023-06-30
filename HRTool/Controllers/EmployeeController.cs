using HRTool.BL;
using HRTool.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employee;

        public EmployeeController(IEmployeeManager employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Route("/Employee/{id}")]
        public ActionResult<GetEmployeeByIdDto> GetEmployeeById(int id)
        {
            var Employee = _employee.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound();
            }
            var employeeDto = new GetEmployeeByIdDto
            {
                Id = Employee.Id,
                Balance = Employee.Balance,
                Name =Employee.Name,
            };

            return employeeDto;
        }
        [HttpPut]
        [Route("/Employee/{id}")]
        public IActionResult UpdateEmployee(int id,UpdateEmployeeDataDto updateEmployeeDataDto)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            
            employee.Balance = updateEmployeeDataDto.Balance;
            _employee.UpdateEmployee(employee, updateEmployeeDataDto.Balance);

            return Ok(employee);
        }

    }
}
