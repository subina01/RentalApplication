using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Models
{
    public class Vehicle
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

        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set;}

        //Navigation Properties 
        public virtual ICollection<Rental> Bookings { get; set; }

    }
}
