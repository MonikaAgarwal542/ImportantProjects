using CampBookingApi.Repository;
using Data_Access_layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_layer
{
    public class CampDAL
    {
        public CampDbContext _dbcontext;
        public CampDAL(CampDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        public bool AddCamp(Camps camp)
        {
           
            _dbcontext.Add(camp);
            _dbcontext.SaveChanges();
            return true;

        }
        public List<Camps> GetAllCamps()
        {
            //var db = new CampDbContext();
            return _dbcontext.Camps.ToList();
        }
        public void DeleteCamp(int campid)
        {
            _dbcontext.Camps.Remove(_dbcontext.Camps.Find(campid));
            _dbcontext.SaveChanges();

        }

        public Camps GetCampById(int campid)
        {
            var ans = _dbcontext.Camps.SingleOrDefault(x => x.CampId == campid);
            return ans;
        }
        public bool UpdateCamp(int campid,Camps camp)
        {
            var existingcamp = _dbcontext.Camps.Where(a => a.CampId == campid).FirstOrDefault();
            if (existingcamp != null) {
                existingcamp.Campname = camp.Campname;
                existingcamp.Capacity = camp.Capacity;
                existingcamp.Description = camp.Description;
                existingcamp.Imageurl = camp.Imageurl;
                existingcamp.Ratepernightforweekdays = camp.Ratepernightforweekdays;
                existingcamp.Ratepernightforweekend = camp.Ratepernightforweekend;
               /* existingcamp.Availablefrom = camp.Availablefrom;
                existingcamp.Availableto = camp.Availableto;*/


                //_dbcontext.Entry(camp).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return true;

            }
            else return false;

        }
    }
}
