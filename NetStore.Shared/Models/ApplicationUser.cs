﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace NetStore.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required] [MaxLength(50)] public string FirstName { get; set; }
        [Required] [MaxLength(50)] public string LastName { get; set; }
        [AllowNull] public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        
    }
}