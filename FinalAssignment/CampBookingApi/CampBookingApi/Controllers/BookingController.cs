using Business_Logic_Layer.Models;
using CampBookingApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampBookingApi.Controllers
{
    [Route("Camp/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private Business_Logic_Layer.BookingBLL _bookingbll;
        private CampDbContext _dbcontext;
        public BookingController(CampDbContext dbContext)
        {
            _dbcontext = dbContext;
            _bookingbll = new Business_Logic_Layer.BookingBLL(_dbcontext);


        }
        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingModel u)
        {
            if (_bookingbll.AddBooking(u)) return Ok("Success");
            else return Ok("Already Exists");

        }
        [Route("getCamp/{BookingReferenceNumber}")]
        [HttpGet]
        public CampModel GetCampByBookingReferenceId(string BookingReferenceNumber)
        {
            CampModel camp = _bookingbll.GetBookingById(BookingReferenceNumber);
            return camp;
           /* if (camp != null) return Ok(camp);
            else return Ok("NoCamp");*/
        }
        [Route("getBooking/{BookingReferenceNumber}")]
        [HttpGet]
        public BookingModel GetBookingByBookingReferenceId(string BookingReferenceNumber)
        {
            BookingModel booking = _bookingbll.GetBookingByRefId(BookingReferenceNumber);
            return booking;
           /* if (booking != null) return Ok(booking);
            else return Ok("NoBooking");*/
        }
        [Route("DeleteBooking/{BookingReferenceNumber}")]
        [HttpDelete]
        public IActionResult DeleteCamp(string BookingReferenceNumber)
        {
            var booking = _bookingbll.GetBookingByRefId(BookingReferenceNumber);
            if (booking != null) {
                _bookingbll.DeleteBooking(BookingReferenceNumber);
                return Ok("Deleted");
            }
            else return Ok("Not Deleted");

        }
        [Route("getBookingbyid/{bookingid}")]
        [HttpGet]
        public BookingModel GetBookingByBookingId(int bookingid)
        {
            BookingModel booking = _bookingbll.GetBookingByBookingId(bookingid);
            return booking;
           /* if (booking != null) return Ok(booking);
            else return Ok("NoBooking");*/
        }

    }
}
