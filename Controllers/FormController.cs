using DevPloyApiApi.Services.FormServices;
using DevPloyClasses.Dto.FormsDto;
using DevPloyClasses.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevPloyApiApi.Controllers
{
    /// <summary>
    /// TODO: Implement Error Handeling
    /// TODO: Add GoogleAuth and other third part Auth
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormServices _formService;
        public FormController(IFormServices formService)
        {
            this._formService = formService;
        }

        /// <summary>
        /// Post on db a base users forms
        /// </summary>
        /// <param name="form">according to BaseFormDto</param>
        /// <returns>post resoult message</returns>
        /// <response code="500">If there is an internal server error</response>
        [HttpPost("Post_BaseForm")]
        public async Task<ActionResult<ServiceResponse<bool>>> PostBaseForm(BaseFormDto form)
        {
            try
            {
                var response = await _formService.PostBaseForm(form);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Post on db a advanced users forms
        /// </summary>
        /// <param name="form">according to AdvancedFormDto</param>
        /// <returns>post resoult message</returns>
        /// <response code="500">If there is an internal server error</response>
        [HttpPost("Post_AdvancedForm")]
        public async Task<ActionResult<ServiceResponse<bool>>> PostAdvavacedForm(AdvancedFormDto form)
        {
            try
            {
                var response = await _formService.PostAdvandcedForm(form);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
