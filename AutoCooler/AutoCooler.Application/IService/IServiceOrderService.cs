using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IService
{
    public interface IServiceOrderService
    {
        Task<ServiceOrder> CreateServiceOrder(ServiceOrder serviceOrder);
        Task<ServiceOrder> UpdateServiceOrder(int serviceOrderId, ServiceOrder serviceOrder);
        Task<IEnumerable<ServiceOrderForTechnicianDto>> GetServiceOrdersByTechnician(int technicianId);
        Task<ServiceOrderForTechnicianDto> GetServiceOrderById(int serviceOrderId);
        Task<IEnumerable<ServiceOrderForTechnicianDto>> GetAllByCompany(int companyId);
    }
}
