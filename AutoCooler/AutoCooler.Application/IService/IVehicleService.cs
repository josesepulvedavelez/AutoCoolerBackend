using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IService
{
    public interface IVehicleService
    {
        Task<Vehicle> CreateVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAllVehiclesByCompany(int companyId);
        Task<List<Vehicle>> GetAllVehiclesByCustomer(int employeeId);
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<Vehicle> UpdateVehicle(int vehicleId, Vehicle vehicle);        
    }
}
