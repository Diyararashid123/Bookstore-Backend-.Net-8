using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendandAuthAPI.Context;
using BackendandAuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendandAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContex _authContext;
      
        public UserController(AppDbContex appDbContex) 
        
        {
            _authContext = appDbContex;

        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null) return BadRequest();
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Username == userObj.Username && x.Password == userObj.Password);
            if (user == null) return NotFound(new { Message = "User nor Found!" });

            return Ok(
                new
                {
                    Message = "Login successful"
                });
        }
            [HttpPost("register")]

            public async Task<IActionResult> RegisterUser([FromBody] User userObj)
            {
                if (userObj == null) 
                    return BadRequest();

                await _authContext.Users.AddAsync(userObj);
                await _authContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "User Register!"
                });
            }


        }

    }

