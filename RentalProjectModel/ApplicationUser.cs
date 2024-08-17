﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
     public string? FullName { get; set; }
        public string? Address { get; set; }

        //Navigation Properties
         
        public virtual ICollection<Rental> Bookings { get; set; }

    }
}
