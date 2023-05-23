using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access_layer.Repository.Entities
{
    public class Booking
    {
        [Key]
        public int Bookingid { get; set; }

        public string Adress { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
        public long Cellphone { get; set; }
        public string Bookingreferencenumber { get; set; }
        public long Totalprice { get; set; }
        public int Totalstay { get; set; }
        public int Campid { get; set; }
        public int Userid { get; set; }
        public DateTime Bookingfrom { get; set; }
        public DateTime Bookingto { get; set; }
         // public virtual int Userid{get;set;}

    }
}
