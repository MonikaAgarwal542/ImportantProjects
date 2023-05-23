using CampBookingApi.Repository;
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
    public class UserController : ControllerBase
    {
        private Business_Logic_Layer.UserBLL _userbll;
        private CampDbContext _dbcontext;
        public UserController(CampDbContext dbContext)
        {
            _dbcontext = dbContext;
            _userbll = new Business_Logic_Layer.UserBLL(_dbcontext);


        }
        [Route("getUser/{Email}")]
        [HttpGet]
        public IActionResult GetBookingByBookingReferenceId(string Email)
        {
            var user = _userbll.GetUserByemailid(Email);
            if (user != null) return Ok(user);
            else return Ok("NoUser");
        }

    }
}
