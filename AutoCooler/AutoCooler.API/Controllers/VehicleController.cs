using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCooler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] Vehicle vehicle)
        {            
            var createdVehicle = await _vehicleService.CreateVehicle(vehicle);
            
            return Ok(createdVehicle);
        }

        [HttpGet("GetAllVehiclesByCompany/{companyId}")]
        public async Task<IActionResult> GetAllVehiclesByCompany(int companyId)
        {
            var vehicles = await _vehicleService.GetAllVehiclesByCompany(companyId);

            return Ok(vehicles);
        }

        [HttpGet("GetAllVehiclesByCustomer/{employeeId}")]
        public async Task<IActionResult> GetAllVehiclesByCustomer(int employeeId)
        {
            var vehicles = await _vehicleService.GetAllVehiclesByCustomer(employeeId);
            
            return Ok(vehicles);        
        }

        [HttpGet("GetVehicleById/{vehicleId}")]
        public async Task<IActionResult> GetVehicleById(int vehicleId)
        {
            var vehicle = await _vehicleService.GetVehicleById(vehicleId);
                        
            return Ok(vehicle);
        }

        [HttpPut("UpdateVehicle/{vehicleId}")]
        public async Task<IActionResult> UpdateVehicle(int vehicleId, [FromBody] Domain.Entity.Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data is required.");
            }
            var updatedVehicle = await _vehicleService.UpdateVehicle(vehicleId, vehicle);
            if (updatedVehicle == null)
            {
                return NotFound($"Vehicle with ID {vehicleId} not found.");
            }
            return Ok(updatedVehicle);
        }

    }
}
