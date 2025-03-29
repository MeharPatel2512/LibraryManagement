using Library.Business.Interface;
using Library.Exceptions.CustomExceptions;
using Library.Models.Request;
using Library.Models.Response;
using Library.Utility.Config;
using Library.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    [Route("api/admin")]
    // [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorInfo))]
    public class AdminController : Controller
    {
        private readonly IAdminBusiness _adminBusiness;

        public AdminController(IAdminBusiness adminBusiness){
            _adminBusiness = adminBusiness;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GetAllUsers(){
            var response = await _adminBusiness.GetALlUsers();
            if(response != null) 
                return Ok(new ApiResponse{
                    Error_status = false,
                    Message = MessageConstants.SuccessMessageList,
                    Code = CodeConstants.GET_DATA_SUCCESSFUL_200,
                    Response = response
                });
            else 
            return Ok(new ApiResponse{
                Error_status = true,
                Message = MessageConstants.NoContent,
                Code = CodeConstants.GET_DATA_NO_DATA_FOUND_204,
                Response = null
            });
        }
    }
}