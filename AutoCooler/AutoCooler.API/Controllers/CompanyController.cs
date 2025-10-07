using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCooler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetCompany/{companyId}")]
        public async Task<IActionResult> GetCompany(int companyId)
        {
            var company = await _companyService.GetCompany(companyId);
            
            if (company == null)
            {
                return NotFound();
            }
            
            return Ok(company);
        }

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            var companyCreated = await _companyService.CreateCompany(company);

            return Ok(companyCreated);
        }

        [HttpPut("UpdateCompany/{companyId}")]
        public async Task<IActionResult> UpdateCompany(int companyId, [FromBody]Company company)
        { 
            var companyUpdated = await _companyService.UpdateCompany(companyId, company);

            return Ok(companyUpdated);
        }

    }
}
