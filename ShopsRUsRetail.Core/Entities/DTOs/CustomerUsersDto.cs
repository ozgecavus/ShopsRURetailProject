﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Entities.DTOs
{
    public class CustomerUsersDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string JoinedIn { get; set; }
        public string UserType { get; set; }
    }
}
