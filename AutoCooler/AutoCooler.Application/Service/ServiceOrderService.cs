using AutoCooler.Application.IRepository;
using AutoCooler.Application.IService;
using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.Service
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public ServiceOrderService(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public Task<ServiceOrder> CreateServiceOrder(ServiceOrder serviceOrder)
        {
            var createdServiceOrder = _serviceOrderRepository.CreateServiceOrder(serviceOrder);

            return createdServiceOrder;
        }

        public Task<ServiceOrder> UpdateServiceOrder(int serviceOrderId, ServiceOrder serviceOrder)
        {
            var updatedServiceOrder = _serviceOrderRepository.UpdateServiceOrder(serviceOrderId, serviceOrder);

            return updatedServiceOrder;
        }
        public Task<IEnumerable<ServiceOrderForTechnicianDto>> GetServiceOrdersByTechnician(int technicianId)
        {
            var serviceOrders = _serviceOrderRepository.GetServiceOrdersByTechnician(technicianId);

            return serviceOrders;
        }

        public Task<ServiceOrderForTechnicianDto> GetServiceOrderById(int serviceOrderId)
        {
            var serviceOrder = _serviceOrderRepository.GetServiceOrderById(serviceOrderId);

            return serviceOrder;
        }

        public Task<IEnumerable<ServiceOrderForTechnicianDto>> GetAllByCompany(int companyId)
        {
            var serviceOrders = _serviceOrderRepository.GetAllByCompany(companyId);
            return serviceOrders;
        }

    }
}
