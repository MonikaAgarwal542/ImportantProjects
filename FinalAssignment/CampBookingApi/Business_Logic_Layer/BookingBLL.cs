using AutoMapper;
using Business_Logic_Layer.Models;
using CampBookingApi.Repository;
using Data_Access_layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public class BookingBLL
    {
        private Data_Access_layer.BookingDAL _bookingdal;
        private Mapper _bookingpmapper;
        private Mapper _campmapper;

        private CampDbContext _dbcontext;

        public BookingBLL(CampDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _bookingdal = new Data_Access_layer.BookingDAL(_dbcontext);
            var _configurationbooking = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>().ReverseMap());
            _bookingpmapper = new Mapper(_configurationbooking);
            var _configurationcamp = new MapperConfiguration(cfg => cfg.CreateMap<Camps, CampModel>().ReverseMap());
            _campmapper = new Mapper(_configurationcamp);

        }
        public bool AddBooking(BookingModel u)
        {

            Booking booking = _bookingpmapper.Map<BookingModel, Booking>(u);

            //user.MemberSince = DateTime.Now;
            return _bookingdal.AddBooking(booking);
        }
        public CampModel GetBookingById(string bookingreferenceid)
        {
            Camps camp = _bookingdal.GetCampById(bookingreferenceid);
            
            CampModel c = _campmapper.Map<Camps, CampModel>(camp);
            return c;

        }
        public BookingModel GetBookingByRefId(string bookingreferenceid)
        {
            Booking booking = _bookingdal.GetBookingById(bookingreferenceid);
            BookingModel c = _bookingpmapper.Map<Booking, BookingModel>(booking);
            return c;

        }
        public void DeleteBooking(string bookingreferenceid)
        {
            //Camps camp= _campmapper.Map<CampModel,Camps>(campmodel);
            _bookingdal.DeleteBooking(bookingreferenceid);


        }
        public BookingModel GetBookingByBookingId(int bookingid)
        {
            Booking booking = _bookingdal.GetBookingByBookingId(bookingid);
            BookingModel c = _bookingpmapper.Map<Booking, BookingModel>(booking);
            return c;

        }
    }
}
