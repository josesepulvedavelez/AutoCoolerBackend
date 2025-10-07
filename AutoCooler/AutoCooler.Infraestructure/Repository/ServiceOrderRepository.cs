using AutoCooler.Application.IRepository;
using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Infraestructure.Repository
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly AutoCoolerContext _context;

        public ServiceOrderRepository(AutoCoolerContext context)
        {
            _context = context;
        }
               
        public async Task<ServiceOrder> CreateServiceOrder(ServiceOrder serviceOrder)
        {
            _context.ServiceOrder.Add(serviceOrder);
            await _context.SaveChangesAsync();
            
            return serviceOrder;
        }

        public async Task<ServiceOrder> UpdateServiceOrder(int serviceOrderId, ServiceOrder serviceOrder)
        {
            var existingServiceOrder = _context.ServiceOrder.Find(serviceOrderId);

            if (existingServiceOrder == null)
            {
                return null;
            }

            existingServiceOrder.Type = serviceOrder.Type;
            existingServiceOrder.OrderDate = serviceOrder.OrderDate;
            existingServiceOrder.Activities = serviceOrder.Activities;
            existingServiceOrder.Observations = serviceOrder.Observations;
            existingServiceOrder.Status = serviceOrder.Status;
            existingServiceOrder.VehicleId = serviceOrder.VehicleId;
            existingServiceOrder.TechnicianId = serviceOrder.TechnicianId;

            _context.ServiceOrder.Update(existingServiceOrder);
            await _context.SaveChangesAsync();

            return existingServiceOrder;
        }

        public async Task<IEnumerable<ServiceOrderForTechnicianDto>> GetServiceOrdersByTechnician(int technicianId)
        {
            var serviceOrders = await (
                    from so 
                        in _context.ServiceOrder
                    join v 
                        in _context.Vehicle on so.VehicleId equals v.VehicleId
                    join c 
                        in _context.Customer on v.CustomerId equals c.CustomerId
                    join os
                        in _context.OrderStatus on so.Status equals os.StatusId
                    where so.TechnicianId == technicianId
                    select new ServiceOrderForTechnicianDto
                    {
                        CompanyId = so.CompanyId,

                        CustomerId = c.CustomerId,
                        Name = c.Name,
                        Adress = c.Address,
                        Phone = c.Phone,

                        VehicleId = v.VehicleId,
                        Plate = v.Plate,
                        Make = v.Make,
                        Model = v.Model,

                        ServiceOrderId = so.ServiceOrderId,
                        Type = so.Type,
                        OrderDate = so.OrderDate,
                        Activities = so.Activities,
                        Observations = so.Observations,
                        Status = so.Status,
                        TechnicianId = so.TechnicianId,

                        StatusName = os.StatusName
                    }
                )
                .OrderByDescending(so => so.OrderDate)
                .ToListAsync();

            return serviceOrders;
        }

        public async Task<ServiceOrderForTechnicianDto> GetServiceOrderById(int serviceOrderId)
        {
            var serviceOrder = await(
                    from so
                        in _context.ServiceOrder
                    join v
                        in _context.Vehicle on so.VehicleId equals v.VehicleId
                    join c
                        in _context.Customer on v.CustomerId equals c.CustomerId
                    join os
                        in _context.OrderStatus on so.Status equals os.StatusId
                    where so.ServiceOrderId == serviceOrderId
                    select new ServiceOrderForTechnicianDto
                    {
                        CompanyId = so.CompanyId,

                        CustomerId = c.CustomerId,
                        Name = c.Name,
                        Adress = c.Address,
                        Phone = c.Phone,

                        VehicleId = v.VehicleId,
                        Plate = v.Plate,
                        Make = v.Make,
                        Model = v.Model,

                        ServiceOrderId = so.ServiceOrderId,
                        Type = so.Type,
                        OrderDate = so.OrderDate,
                        Activities = so.Activities,
                        Observations = so.Observations,
                        Status = so.Status,
                        TechnicianId = so.TechnicianId,

                        StatusName = os.StatusName
                    }
                ).FirstOrDefaultAsync();

            return serviceOrder;
        }

        public async Task<IEnumerable<ServiceOrderForTechnicianDto>> GetAllByCompany(int companyId)
        {
            var serviceOrders = await(
                    from so
                        in _context.ServiceOrder
                    join v
                        in _context.Vehicle on so.VehicleId equals v.VehicleId
                    join c
                        in _context.Customer on v.CustomerId equals c.CustomerId
                    where so.CompanyId == companyId
                    select new ServiceOrderForTechnicianDto
                    {
                        CompanyId = so.CompanyId,

                        CustomerId = c.CustomerId,
                        Name = c.Name,
                        Adress = c.Address,
                        Phone = c.Phone,

                        VehicleId = v.VehicleId,
                        Plate = v.Plate,
                        Make = v.Make,
                        Model = v.Model,

                        ServiceOrderId = so.ServiceOrderId,
                        Type = so.Type,
                        OrderDate = so.OrderDate,
                        Activities = so.Activities,
                        Observations = so.Observations,
                        Status = so.Status,
                        TechnicianId = so.TechnicianId
                    }
                ).ToListAsync();

            return serviceOrders;
        }

    }
}
