using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using ReportApp.Core.Interfaces;

namespace ReportApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var result = await _employeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("get-id/{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(Int32 id)
        {
            var result = await _employeeService.GetEmployeeAsync(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateEmployeeAsync(EmployeeDto employee)
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateEmployeeAsync(EmployeeDto employee)
        {
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }
    }
}
