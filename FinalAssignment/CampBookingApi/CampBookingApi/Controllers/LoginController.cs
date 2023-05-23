using Business_Logic_Layer.Models;
using CampBookingApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampBookingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class LoginController : ControllerBase
    {
        private Business_Logic_Layer.UserBLL _userbll;
        private CampDbContext _dbcontext;
        private readonly IConfiguration _config;
        public LoginController(CampDbContext dbContext,IConfiguration config)
        {
            _dbcontext = dbContext;
            _userbll = new Business_Logic_Layer.UserBLL(_dbcontext);
            _config = config;


        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel u)
        {
            if (_userbll.Login(u)) {
                //Console.WriteLine(u);
                return Ok(new JwtService(_config).GenerateToken(u.Email));
            } 
            else return Ok("Failure");




        }



    }
}
