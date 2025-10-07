using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCooler.API.Controllers
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

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            var employeeCreated = await _employeeService.CreateEmployee(employee);

            return Ok(employeeCreated);
        }

        [HttpGet("GetAllEmployeesByCompany")]
        public async Task<IActionResult> GetAllEmployeesByCompany(int companyId)
        {
            var employees = await _employeeService.GetAllEmployeesByCompany(companyId);
            return Ok(employees);
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeById(employeeId);
            
            return Ok(employee);
        }

        [HttpPut("UpdateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(employeeId, employee);
                        
            return Ok(updatedEmployee);
        }

    }
}
