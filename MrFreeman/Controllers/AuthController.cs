using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MrFreeman.Filters;

namespace MrFreeman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateModel]
        public IActionResult Register(UserRegisterRequest userRegister) 
        {
            if (_auth.CheckUserIsExist(userRegister.Email))
            {
                return BadRequest("There is already a user with this email.");
            }

            try
            {
                _auth.RegisterUser(userRegister);
            }
            catch (Exception)
            {
                return BadRequest("Error when creating user.");
            }

            return Ok("User successfully created.");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(string email, string password)
        {
            if (!_auth.CheckUserIsExist(email))
            {
                return BadRequest("There is no user with this email.");
            }

            // Megnézi, hogy az email meg lett-e erősítve

            if (_auth.VerifyLoginData(email, password, out string token))
            {
                return Ok(token);
            }
            else
            {
                return BadRequest("Incorrect login details.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VerifyEmail(string token)
        {
            bool isVerified = _auth.VerifyEmail(token);

            if (!isVerified)
            {
                return BadRequest("Invalid confirmation token.");
            }

            return Ok("Successful email confirmation.");
        }
    }
}
