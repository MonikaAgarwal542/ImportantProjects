using AutoMapper;
using Business_Logic_Layer.Models;
using CampBookingApi.Repository;
using Data_Access_layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer
{
    public class CampBLL
    {
        private Data_Access_layer.CampDAL _campdal;
        private Mapper _campmapper;

        private CampDbContext _dbcontext;

        public CampBLL(CampDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _campdal = new Data_Access_layer.CampDAL(_dbcontext);
            var _configurationcamp = new MapperConfiguration(cfg => cfg.CreateMap<Camps, CampModel>().ReverseMap());
            _campmapper = new Mapper(_configurationcamp);
           
        }
        public bool AddCamp(CampModel u)
        {
            Camps camps = _campmapper.Map<CampModel, Camps>(u);

            //user.MemberSince = DateTime.Now;
            return _campdal.AddCamp(camps);
        }

        public List<CampModel> GetAllCamps()
        {

            List<Camps> camplist = _campdal.GetAllCamps();
            List<CampModel> camps = _campmapper.Map<List<Camps>, List<CampModel>>(camplist);
            return camps;

        }

        public void  DeleteCamp(int campid)
        {
            //Camps camp= _campmapper.Map<CampModel,Camps>(campmodel);
            _campdal.DeleteCamp(campid);
          
           
        }
        

        public CampModel GetCampById(int campid)
        {
           Camps camp=  _campdal.GetCampById(campid);
           CampModel c = _campmapper.Map<Camps, CampModel>(camp);
            return c;

        }
        public bool UpdateCamp(int campid,CampModel campmodel)
        {
            Camps camp = _campmapper.Map<CampModel, Camps>(campmodel);
            if (_campdal.UpdateCamp(campid, camp))
                return true;
            else return false;
           

        }
    }
}
