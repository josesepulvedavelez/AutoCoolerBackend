using AutoCooler.Application.IRepository;
using AutoCooler.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Infraestructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AutoCoolerContext _autoCoolerContext;

        public VehicleRepository(AutoCoolerContext autoCoolerContext) 
        {
            _autoCoolerContext = autoCoolerContext;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            var createdVehicle = _autoCoolerContext.Vehicle.Add(vehicle);
            _autoCoolerContext.SaveChanges();

            return createdVehicle.Entity;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesByCompany(int companyId)
        {
            var vehicles = await (from customer in _autoCoolerContext.Customer
                                  join vehicle in _autoCoolerContext.Vehicle
                                  on customer.CustomerId equals vehicle.CustomerId
                                  where customer.CompanyId == companyId
                                  select vehicle).ToListAsync();

            return vehicles;
        }

        public async Task<List<Vehicle>> GetAllVehiclesByCustomer(int employeeId)
        {
            var vehicles = _autoCoolerContext.Vehicle
                            .Where(v => v.CustomerId == employeeId)
                            .ToList();

            return vehicles;
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            var vehicle = _autoCoolerContext.Vehicle
                           .FirstOrDefault(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return null;
            }

            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            var existingVehicle = _autoCoolerContext.Vehicle
                .FirstOrDefault(v => v.VehicleId == vehicleId);

            if (existingVehicle == null)
            {
                return null;
            }

            existingVehicle.Plate = vehicle.Plate;
            existingVehicle.Make = vehicle.Make;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.CustomerId = vehicle.CustomerId;

            _autoCoolerContext.Vehicle.Update(existingVehicle);
            _autoCoolerContext.SaveChanges();

            return existingVehicle;
        }

    }
}
