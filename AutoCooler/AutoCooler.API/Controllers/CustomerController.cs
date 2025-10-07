using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCooler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerService.CreateCustomer(customer);

            return Ok(createdCustomer);
        }

        [HttpGet("GetAllCustomersByCompany/{companyId}")]
        public async Task<IActionResult> GetAllCustomersByCompany(int companyId)
        {
            var customers = await _customerService.GetAllCustomersByCompany(companyId);

            return Ok(customers);
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);

            return Ok(customer);
        }

        [HttpPut("UpdateCustomer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] Customer customer)
        {
            var updatedCustomer = await _customerService.UpdateCustomer(customerId, customer);

            return Ok(updatedCustomer);
        }

    }
}
