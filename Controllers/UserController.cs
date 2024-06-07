using Microsoft.AspNetCore.Mvc;
using DevPloyClasses.Models;
using DevPloyClasses.Dto.UserDtos;
using AgentBuilderApi.Services.UserServices;

namespace AgentBuilderApi.Controllers
{
    /// <summary>
    /// TODO: Implement Error Handeling
    /// TODO: Add GoogleAuth and other third part Auth
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

        /// <summary>
        /// TODO: need to implement OTP message
        /// Try to validate user acces
        /// </summary>
        /// <param name="user">UserLogIn data tranfert obj</param>
        /// <returns>if user validated return JWT</returns>
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
        /// We get the basic required info from client taking care to keep separated uncripted pasword
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
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
