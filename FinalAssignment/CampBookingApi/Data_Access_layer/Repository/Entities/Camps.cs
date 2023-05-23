using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access_layer.Repository.Entities
{
    public class Camps
    {
        [Key]
        public int CampId { get; set; }

       
        public string Campname { get; set; }

        public int Ratepernightforweekdays { get; set; }
        public int Ratepernightforweekend { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public DateTime Availablefrom { get; set; }
        public DateTime Availableto { get; set; }
        public string Imageurl { get; set; }
        public int Bookingid { get; set; }
        public  ICollection<Ratings> rating { get; set; }
    }
}
