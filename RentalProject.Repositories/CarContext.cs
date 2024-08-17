using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Repositories
{
    public class CarContext : IdentityDbContext<ApplicationUser>
    {
     
        public CarContext(DbContextOptions<CarContext> options):base(options) 
        {
        
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
