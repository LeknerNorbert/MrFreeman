using BusinessLogicLayer.AuthService;
using BusinessLogicLayer.EmailService;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.UserService;
using Microsoft.AspNetCore.Mvc;
using MrFreeman.Filters;

namespace MrFreeman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IUserService userService, IEmailService emailService)
        {
            _authService = authService;
            _userService = userService; 
            _emailService = emailService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateModel]
        public IActionResult Register(UserRegisterRequest userRegister) 
        {
            if (_userService.CheckUserIsExist(userRegister.Email))
            {
                return BadRequest("There is already a user with this email.");
            }

            try
            {
                _authService.RegisterUser(userRegister);
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
            if (!_userService.CheckUserIsExist(email))
            {
                return BadRequest("There is no user with this email.");
            }

            // Megnézi, hogy az email meg lett-e erősítve

            if (_authService.VerifyLoginData(email, password, out string token))
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
            bool isVerified = _authService.VerifyEmail(token);

            if (!isVerified)
            {
                return BadRequest("Invalid confirmation token.");
            }

            return Ok("Successful email confirmation.");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SendVerifyEmail(string email)
        {
            if(_userService.CheckUserIsExist(email))
            {
                return BadRequest("There is no user with this email.");
            }

            User? user = _userService.FindUserByEmail(email);

            string subject = "Account verification";
            string body = $"<b>{user.VerificationToken}</b>";

            try
            {
                _emailService.SendEmail(email, subject, body);
            }
            catch (Exception)
            {
                return BadRequest("Can't sent the verify email.");
            }

            return Ok("Verify email sent.");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SendPasswordResetEmail()
        {
            return Ok();
        }
    }
}
