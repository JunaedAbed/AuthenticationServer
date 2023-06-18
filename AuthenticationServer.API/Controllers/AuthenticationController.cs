using AuthenticationServer.BLL.Services.PasswordHashers;
using AuthenticationServer.BLL.Services.UserRepositories;
using AuthenticationServer.DAL.Models;
using AuthenticationServer.DAL.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.API.Controllers
{
    public class AuthenticationController: Controller
    {
        private readonly IUserRespository userRespository;
        private readonly IPasswordHasher passwordHasher;

        public AuthenticationController(IUserRespository userRespository, IPasswordHasher passwordHasher)
        {
            this.userRespository = userRespository;
            this.passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if(!ModelState.IsValid) return BadRequest();

            if(registerRequest.Password != registerRequest.ConfirmPassword) return BadRequest();

            User existingUserByEmail = await userRespository.GetByEmail(registerRequest.Email);
            if (existingUserByEmail != null) return Conflict();

            User existingUserByUsername = await userRespository.GetByUsername(registerRequest.Username);
            if (existingUserByUsername != null) return Conflict();

            User registerUser = new User() 
            { 
                Email = registerRequest.Email, 
                Username = registerRequest.Username,
                Password = passwordHasher.HashPassword(registerRequest.Password),
            };

            await userRespository.CreateUser(registerUser);

            return Ok(registerUser);
        }
    }
}
