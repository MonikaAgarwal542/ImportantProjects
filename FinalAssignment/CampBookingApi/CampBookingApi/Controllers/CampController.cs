using Business_Logic_Layer.Models;
using CampBookingApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CampBookingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampController : ControllerBase
    {
        private Business_Logic_Layer.CampBLL _campbll;
        private CampDbContext _dbcontext;
        private Business_Logic_Layer.BookingBLL _bookingbll;
        public CampController(CampDbContext dbContext)
        {
            _dbcontext = dbContext;
            _campbll = new Business_Logic_Layer.CampBLL(_dbcontext);
            _bookingbll = new Business_Logic_Layer.BookingBLL(_dbcontext);

        }
       
        [HttpPost("AddCamp")]
        public IActionResult AddCamp([FromBody] CampModel u)
        {
            if (_campbll.AddCamp(u)) return Ok("Success");
            else return Ok("Already Exists");

        }

        [Route("AllCamps")]
        [HttpGet]
        public List<CampModel> GetAllCamps()
        {
            return _campbll.GetAllCamps();
        }

        [Route("DeleteCamp/{CampId}")]
        [HttpDelete]
        public IActionResult DeleteCamp(int campid)
        {
            var camp = _campbll.GetCampById(campid);
            if (camp != null) {
                _campbll.DeleteCamp(campid);
                return Ok("Deleted");
            }
            else return Ok("Not Deleted");

        }

         [Route("getCamp/{CampId}")]
         [HttpGet]
         public CampModel GetCampById(int campid) 
         {
            CampModel camp = _campbll.GetCampById(campid);
            return camp;
          }

            [Route("UpdateCamp/{CampId}")]
            [HttpPut]
            public IActionResult UpdateCamp(int campid ,[FromBody ]CampModel campmodel)
            {

            if (_campbll.UpdateCamp(campid, campmodel)) return Ok("Updated");
            else return Ok("Not updTED");
               



        }

       


        [Route("FilteredCamps")]
        [HttpGet]
        public IEnumerable<CampModel> GetFilteredCamps([FromQuery] DateTime Availablefrom, DateTime Availableto, int capacity)
        {

         
             IEnumerable<CampModel> filteredcamps;
         
             List<CampModel> allcamps = _campbll.GetAllCamps();
            filteredcamps = allcamps.Where(c => c.Availablefrom <= Availablefrom && c.Availableto >= Availableto && c.Capacity >= capacity && c.Bookingid==0); 
          

           /* filteredcamps = allcamps.Where(c => c.Bookingid == 0 || (_bookingbll.GetBookingByBookingId(c.Bookingid).Bookingfrom>Availablefrom && _bookingbll.GetBookingByBookingId(c.Bookingid).Bookingfrom > Availableto)
            || (_bookingbll.GetBookingByBookingId(c.Bookingid).Bookingto < Availablefrom && _bookingbll.GetBookingByBookingId(c.Bookingid).Bookingto < Availableto)
            );*/

            return filteredcamps;



           }



}
}
