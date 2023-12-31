﻿using HRTool.BL;
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
        #region Calaculate Remainig Balance

        [HttpGet]
        [Route("AnnualBalance/{employeeId}")]
        public IActionResult CalculateRemainingBalance(int employeeId)
        {
            var employee = _employee.CalculateRemainingBalance(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        #endregion

        #region Get All Employees
        [HttpGet]
        public IActionResult GetEmployees ()
        {
            return Ok(_employee.GetEmployees());
        }
        #endregion
    }
}
