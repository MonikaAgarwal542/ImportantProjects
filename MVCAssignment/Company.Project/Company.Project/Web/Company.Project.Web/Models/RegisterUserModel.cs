
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Company.Project.Web.Models
{
    //Register user model for getting and setting register user properties 
    /// <summary>
    /// Getting of the information from Register View()
    /// </summary>
    public class RegisterUserModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please enter a valid name")]
        public string UserName { get; set; }



        [Required]
     //   [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[A-Za-z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid email address")]
        public string EmailId { get; set; }



        [Required]
      
 
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage = "Minimum length should be 5")]
        [RegularExpression(@"(?=.{5,})(?=.*[@#!$%^&+=]).*",ErrorMessage= " Must be at least 5 characters and contain at least one special character.")]
        public string Password { get; set; }



        [NotMapped] // Does not effect with database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
