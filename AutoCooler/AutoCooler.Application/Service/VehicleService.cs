using AutoCooler.Application.IRepository;
using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            var result = await _vehicleRepository.CreateVehicle(vehicle);

            return result;
        }

        public Task<IEnumerable<Vehicle>> GetAllVehiclesByCompany(int companyId)
        {
            var result = _vehicleRepository.GetAllVehiclesByCompany(companyId);

            return result;
        }

        public async Task<List<Vehicle>> GetAllVehiclesByCustomer(int employeeId)
        {
            var result = await _vehicleRepository.GetAllVehiclesByCustomer(employeeId);

            return result;
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            var result = await _vehicleRepository.GetVehicleById(vehicleId);

            return result;
        }

        public async Task<Vehicle> UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            var result = await _vehicleRepository.UpdateVehicle(vehicleId, vehicle);

            return result;
        }

    }    
}
