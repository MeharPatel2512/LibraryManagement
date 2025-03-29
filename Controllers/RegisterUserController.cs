using Library.Business.Interface;
using Library.Models.Request;
using Library.Models.Response;
using Library.Utility.Config;
using Library.Utility.Constants;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/register")]
    // [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorInfo))]
    public class RegisterUserController : Controller
    {
        private readonly IRegisterUserBusiness _registerUserBusiness;

        public RegisterUserController(IRegisterUserBusiness registerUserBusiness){
            _registerUserBusiness = registerUserBusiness;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> RegisterUser(RegisterUserModel.RegisterUserUIModel registerUserUIModel){
            await _registerUserBusiness.RegisterUser(registerUserUIModel);
            return Ok(new ApiResponse{
                Error_status = true,
                Message = MessageConstants.SuccessRegisterMessage,
                Code = CodeConstants.REGISTER_SUCCESSFUL,
                Response = "PLEASE LOGIN NOW"
            });
        }
    }
}