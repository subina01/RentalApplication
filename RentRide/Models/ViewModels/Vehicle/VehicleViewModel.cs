﻿namespace RentRide.Models.ViewModels.Vehicle
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string? VehicleName { get; set; }

        public string? VehicleType { get; set; }

        public string? VehicleModel { get; set; }

        public string? VehicleNumber { get; set; }

        public string? VehicleColor { get; set; }

        public string? VehicleDescription { get; set; }

        public string? VehicleImage { get; set; }

        public string? VehiclePrice { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
