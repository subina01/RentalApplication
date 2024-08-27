using AutoMapper;
using AutoMapper.Configuration.Conventions;
using RentalProject.Models;
using RentRide.Models.ViewModels.Vehicle;

namespace RentRide.Mapper
{
    public class VehicleProfile:Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>();
        }
    }
}
