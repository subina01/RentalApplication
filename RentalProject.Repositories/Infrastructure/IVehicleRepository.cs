using RentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Repositories.Infrastructure
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicleById(int Id);

        Task InsertVehicle(Vehicle vehicle);

        Task UpdateVehicle( Vehicle vehicle);

        Task DeleteVehicle(int Id);

        

    }
}
