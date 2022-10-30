﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Entities.DTOs
{
    public class CreateCustomerUserDto
    {
        [Required(ErrorMessage = "FirstName name field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum length for the FirstName field is {0}")]
        public string FirstName { get; set; }

         
        [MaxLength(25, ErrorMessage = "Maximum length for the MiddleName field is {0}")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "LastName name field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum length for the LastName field is {0}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The email provided is not a valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Phone number field is required")]
        [Phone(ErrorMessage = "The phone number provided is not a valid phone number.")]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum Length for the address field is {0}")]
        public string Address { get; set; }

        [Required(ErrorMessage = "User Type field is required")]
        public string UserType { get; set; }
    }
}
