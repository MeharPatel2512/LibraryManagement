using Library.Business.Interface;
using Library.Models.Request;
using Library.Models.Response;
using Library.Utility.Config;
using Library.Utility.Constants;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/login")]
    // [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorInfo))]
    public class LoginUserController : Controller
    {
        private readonly ILoginUserBusiness _loginUserBusiness;

        public LoginUserController(ILoginUserBusiness loginUserBusiness){
            _loginUserBusiness = loginUserBusiness;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> LoginUser(LoginUserModel.LoginUserUIModel loginUserUIModel){
            LoginUserResponse response = await _loginUserBusiness.LoginUser(loginUserUIModel);
            if(response != null) return Ok(response);
            else return Ok(new ApiResponse{
                Error_status = true,
                Message = MessageConstants.FailedLoginMessage,
                Code = CodeConstants.LOGIN_FAILED,
                Response = null
            });
        }
    }
}