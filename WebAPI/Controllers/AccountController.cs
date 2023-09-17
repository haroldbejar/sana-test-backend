using Appllication.Services.Dtos.UserDto;
using Appllication.Services.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/acount")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService service;

        public AccountController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerUser) 
        {
             var existingUser = await service.GetUserByUserName(registerUser.UserName);
             if (existingUser == null) return Unauthorized();
            
             await service.Register(registerUser);

            var user = new LogedUserDto
            {
                UserName = existingUser.UserName,
                Token = "fddasfsda"
            };
            
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(RegisterDto registerUser)
        {
            var existingUser = await service.GetUserByUserName(registerUser.UserName);
            if (existingUser == null) return Unauthorized();

            using var hmac = new HMACSHA512(existingUser.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password));

            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != existingUser.PasswordHash[i]) return Unauthorized();
                
            }

            var user = new LogedUserDto
            {
                UserName = existingUser.UserName,
                Token = "jdflajdfla"
            };

            return Ok(user);
        }


    }
}
