using Business_Logic_Layer.Models;
using CampBookingApi.Repository;
using CampBookingApi.Repository.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampBookingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SignUpController : ControllerBase
    {
        private Business_Logic_Layer.UserBLL _userbll;
        private CampDbContext _dbcontext;
        public SignUpController(CampDbContext dbContext)
        {
            _dbcontext = dbContext;
            _userbll = new Business_Logic_Layer.UserBLL(_dbcontext);


        }
     
       [AllowAnonymous]
        [HttpPost]
        public IActionResult postuser([FromBody] SignupModel u)
        {
            if (_userbll.postuser(u)) return Ok("Success");
            else return Ok("Already Exists");
           

           

        }
        [Route("AllUsers")]
        [HttpGet]
        public List<SignupModel> getallusers()
        {
            return _userbll.getallusers();
        }

       /* [Route("OneUsers")]
        [HttpGet]
        public Users getallusers(int id)
        {
            var db = new CampDbContext(_dbcontext);
            Users u = new Users();
           u= db.Users.FirstOrDefault(x => x.UserId == id);
            return u;
        }*/

    }
}
