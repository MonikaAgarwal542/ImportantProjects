using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Logic_Layer.Models
{
    public class BookingModel
    {
        [Key]
        public int Bookingid { get; set; }

        [Required]
        public string Adress { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int Zipcode { get; set; }
        [Required]
        public long Cellphone { get; set; }
        public string Bookingreferencenumber { get; set; }
        public long Totalprice { get; set; }
        public int Totalstay { get; set; }
        public int Campid { get; set; }
        public int Userid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Bookingfrom { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Bookingto { get; set; }


    }
}
