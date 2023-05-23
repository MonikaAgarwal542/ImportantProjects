using CampBookingApi.Repository.Entites;

using System;
using System.Collections.Generic;
using AutoMapper;
using Business_Logic_Layer.Models;
using CampBookingApi.Repository;

namespace Business_Logic_Layer
{
    public class UserBLL
    {
        private Data_Access_layer.UserDAL _userdal;
        private Mapper _usermapperlogin;
        private Mapper _usermappersignup;
        private CampDbContext _dbcontext;

        public UserBLL(CampDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _userdal = new Data_Access_layer.UserDAL(_dbcontext);
            var _configurationlogin = new MapperConfiguration(cfg => cfg.CreateMap<Users, LoginModel>().ReverseMap());
            var _configurationsignup = new MapperConfiguration(cfg => cfg.CreateMap<Users, SignupModel>().ReverseMap());
            _usermapperlogin = new Mapper(_configurationlogin);
            _usermappersignup = new Mapper(_configurationsignup);

        }
        public List<SignupModel> getallusers()
        {

            List<Users> userlist= _userdal.getallusers();
            List<SignupModel> userans= _usermappersignup.Map<List<Users>, List<SignupModel>>(userlist);
            return userans;
            
        }
        public bool postuser( SignupModel u)
        {
            Users user= _usermappersignup.Map<SignupModel, Users> (u);

            user.MemberSince = DateTime.Now;
           return  _userdal.postuser(user);
        }
        public bool Login(LoginModel u)
        {
            Users user = _usermapperlogin.Map<LoginModel, Users>(u);

            user.MemberSince = DateTime.Now;
            return _userdal.Login(user);
        }

        public SignupModel GetUserByemailid(string email)
        {

            Users user = _userdal.GetUserByEmailId(email);
            Console.WriteLine(user);
           
            SignupModel c = _usermappersignup.Map<Users,SignupModel>(user);
            return c;

        }

    }
}
