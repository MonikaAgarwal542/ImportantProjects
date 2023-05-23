using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic_Layer.Models
{
   public  class CampModel
    {
        [Key]
        public int CampId { get; set; }
        [Required]
        public string Campname { get; set; }

        [Required]
        public int Ratepernightforweekdays { get; set; }
        [Required]
        public int Ratepernightforweekend { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Availablefrom { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Availableto { get; set; }
        [Required]
        public string Imageurl { get; set; }
        public int Bookingid { get; set; }

    }
}
