using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business_Logic_Layer.Models
{
   public  class SignupModel
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[A-Za-z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum length should be 5")]
        [RegularExpression(@"(?=.{5,})(?=.*[@#!$%^&+=]).*", ErrorMessage = " Must be at least 5 characters and contain at least one special character.")]
        public string Password { get; set; }
        [NotMapped] // Does not effect with database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
      

    }
}
