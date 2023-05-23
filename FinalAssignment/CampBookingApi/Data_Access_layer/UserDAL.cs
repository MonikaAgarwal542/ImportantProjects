

using CampBookingApi.Repository;
using CampBookingApi.Repository.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_layer
{
    public class UserDAL
    {
        public CampDbContext _dbcontext;
        public UserDAL(CampDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public List<Users> getallusers()
        {
            //var db = new CampDbContext();
            return _dbcontext.Users.ToList();
        }
        public bool postuser(Users user)
        {
            if (_dbcontext.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null) {
                //return Ok("Email aready exists");
                return false;
            }
           // var db = new CampDbContext();
            _dbcontext.Add(user);
            _dbcontext.SaveChanges();
            return true;

        }

        public bool Login(Users user)
        {
            var ans = _dbcontext.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
               if (ans != null) {
              
                return true;
            }
          
            return false;

        }
     
              public Users GetUserByEmailId(string emailid)
        {
            var ans = _dbcontext.Users.SingleOrDefault(x => x.Email == emailid);

            return ans;
        }

    }
}
