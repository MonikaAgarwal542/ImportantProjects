using CampBookingApi.Repository;
using Data_Access_layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_layer
{
   public  class BookingDAL
    {
        public CampDbContext _dbcontext;
        public BookingDAL(CampDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public bool AddBooking(Booking booking)
        {

            _dbcontext.Add(booking);
            _dbcontext.SaveChanges();
           // var user = _dbcontext.Users.SingleOrDefault(x => x.UserId == booking.Userid);
            var camp= _dbcontext.Camps.SingleOrDefault(x => x.CampId == booking.Campid);
            camp.Bookingid = booking.Bookingid;
           
            _dbcontext.SaveChanges();
            return true;

        }
        public Camps GetCampById(string bookingreferencenumber)
        {
            Booking ans = _dbcontext.Bookings.SingleOrDefault(x => x.Bookingreferencenumber == bookingreferencenumber);
            if (ans != null) {
                Camps camp = _dbcontext.Camps.SingleOrDefault(x => x.CampId == ans.Campid);
                if (camp != null)
                    return camp;
                else return null;

            }
            else return null;
           
        }
        public Booking GetBookingById(string bookingreferencenumber)
        {
            Booking ans = _dbcontext.Bookings.SingleOrDefault(x => x.Bookingreferencenumber == bookingreferencenumber);
            if (ans != null)
                return ans;
            else return null;

          ;
        }

        public Booking GetBookingByBookingId(int bookingid)
        {
            Booking ans = _dbcontext.Bookings.SingleOrDefault(x => x.Bookingid == bookingid);
            if (ans != null)
                return ans;
            else return null;

           
        }
        public void DeleteBooking(string bookingreferencenumber)
        {
            Booking ans = _dbcontext.Bookings.SingleOrDefault(x => x.Bookingreferencenumber == bookingreferencenumber);
            Camps camp = _dbcontext.Camps.SingleOrDefault(x => x.CampId == ans.Campid);
            camp.Bookingid = 0;
            _dbcontext.SaveChanges();
            _dbcontext.Bookings.Remove(ans);
            _dbcontext.SaveChanges();

        }
    }
}
