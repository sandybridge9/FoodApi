using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaitynaiNaujas.Models;

namespace SaitynaiNaujas.Controllers
{
    [Route("api/UserLogin")]
    public class UserLoginController : ControllerBase
    {
        private readonly FoodContext _context;

        public UserLoginController(FoodContext context)
        {
            _context = context;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<bool>> Authenticate([FromBody]UserLogin userParam)
        {
            var userLogin = await _context.UserLogins.FirstOrDefaultAsync(ul => ul.Username == userParam.Username && ul.Password == userParam.Password);
            if (userLogin == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(true);
        }
    }
}
