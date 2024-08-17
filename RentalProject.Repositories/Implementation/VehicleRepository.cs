using Microsoft.EntityFrameworkCore;
using RentalProject.Models;
using RentalProject.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Repositories.Implementation
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CarContext _context;

        public VehicleRepository(CarContext context)
        {
            _context = context;
        }

        public async Task DeleteVehicle(int Id)
        {
            var vehicle =  await _context.Vehicles.FindAsync(Id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
                
            }

            
        }

        public async Task<Vehicle> GetVehicleById(int Id)
        {
            var vehicle = await _context.Vehicles.FindAsync(Id); 
            if(vehicle != null)
            {
                return vehicle;
            }
            throw new Exception($"Vehicle with the ID{Id} not found");
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            if(vehicles.Count == 0)
            {
                throw new Exception($"Vehicle Table is Empty");
            }
            return vehicles;
        }

        public async Task InsertVehicle(Vehicle vehicle)
        {
          await  _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            var vehicleFromDb = await _context.Vehicles.FindAsync(vehicle.Id);
             if(vehicleFromDb != null)
            {
                vehicleFromDb.VehicleName = vehicle.VehicleName;
                vehicleFromDb.VehicleType = vehicle.VehicleType;
                vehicleFromDb.VehicleModel = vehicle.VehicleModel;
                vehicleFromDb.VehicleNumber = vehicle.VehicleNumber;
                vehicleFromDb.VehicleColor = vehicle.VehicleColor;
                vehicleFromDb.VehicleDescription = vehicle.VehicleDescription;
                if (vehicle.VehicleImage != null) {
                    vehicleFromDb.VehicleImage = vehicle.VehicleImage;
                }
                vehicleFromDb.VehiclePrice = vehicle.VehiclePrice;
                vehicleFromDb.UpdatedAt = DateTime.UtcNow;
             }
        }
    }
}
