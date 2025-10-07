using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCooler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;

        public ServiceOrderController(IServiceOrderService serviceOrderService)
        {
            _serviceOrderService = serviceOrderService;
        }

        [HttpPost("CreateServiceOrder")]
        public async Task<IActionResult> CreateServiceOrder([FromBody] ServiceOrder serviceOrder)
        {
            var createdServiceOrder = await _serviceOrderService.CreateServiceOrder(serviceOrder);

            return Ok(createdServiceOrder);
        }

        [HttpPut("UpdateServiceOrder/{serviceOrderId}")]
        public async Task<IActionResult> UpdateServiceOrder(int serviceOrderId, [FromBody] ServiceOrder serviceOrder)
        {
            var updatedServiceOrder = await _serviceOrderService.UpdateServiceOrder(serviceOrderId, serviceOrder);

            return Ok(updatedServiceOrder);
        }

        [HttpGet("GetServiceOrdersByTechnician/{technicianId}")]
        public async Task<IActionResult> GetServiceOrdersByTechnician(int technicianId)
        {
            var serviceOrders = await _serviceOrderService.GetServiceOrdersByTechnician(technicianId);

            return Ok(serviceOrders);
        }

        [HttpGet("GetServiceOrderById/{serviceOrderId}")]

        public async Task<IActionResult> GetServiceOrderById(int serviceOrderId)
        {
            var serviceOrder = await _serviceOrderService.GetServiceOrderById(serviceOrderId);

            return Ok(serviceOrder);
        }

        [HttpGet("GetAllByCompany/{companyId}")]
        public async Task<IActionResult> GetAllByCompany(int companyId)
        {
            var serviceOrders = await _serviceOrderService.GetAllByCompany(companyId);

            return Ok(serviceOrders);
        }

    }
}
