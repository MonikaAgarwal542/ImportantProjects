using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access_layer.Repository.Entities
{
   public class Ratings
    {
        [Key]
        public int RatingId { get; set; }
        public int Rating { get; set; }
        public int Campid { get; set; }
        public int userid { get; set; }

    }
}
