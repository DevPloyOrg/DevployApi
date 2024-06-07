using Microsoft.AspNetCore.Mvc;
using DevPloyClasses.Models;
using DevPloyClasses.Dto.UserDtos;
using DevPloyApiApi.Services.UserServices;

namespace DevPloyApiApi.Controllers
{
    /// TODO: Implement Error Handeling
    /// TODO: Add GoogleAuth and other third part Auth
    /// TODO: Check the controller returns
    /// <summary>
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        /// TODO: need to implement OTP message
        /// <summary>
        /// Try to validate user acces 
        /// </summary>
        /// <param name="user">according to UserLogInDto</param>
        /// <returns>if user validated return JWT , will return otp soon</returns>
        /// <response code="500">If there is an internal server error</response>
        [HttpPost("Log_User")]
        public async Task<ActionResult<ServiceResponse<string>>> LogUser(UserDtoLogIn user)
        {
            try
            {
                var response = await _userService.LogIn(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets user account details according in order to register
        /// </summary>
        /// <param name="user">according to class library UserDtoRegister</param>
        /// <returns>user registration message, will return otp soon</returns>
        /// /// <response code="500">If there is an internal server error</response>
        [HttpPost("Register_User")]
        public async Task<ActionResult<ServiceResponse<string>>> PostUser(UserDtoRegister user)
        {
            try
            {
                var response = await _userService.Register(user);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
