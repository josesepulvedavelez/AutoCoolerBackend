using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IRepository
{
    public interface IVehicleRepository
    {
        Task<Vehicle> CreateVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAllVehiclesByCompany(int companyId);
        Task<List<Vehicle>> GetAllVehiclesByCustomer(int employeeId);
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<Vehicle> UpdateVehicle(int vehicleId, Vehicle vehicle);
    }
}
