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
    [Route("api/users")]
    // [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorInfo))]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness){
            _userBusiness = userBusiness;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GetMyProfileData(){
            var response = await _userBusiness.GetMyProfileData();
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
        
        [HttpPost("[action]")]
        public async Task<ActionResult> UpdateMyData(UserModel.UpdateUserDataModel updateUserDataModel){
            await _userBusiness.UpdateMyData(updateUserDataModel);
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageUpdate,
                Code = CodeConstants.UPSERT_SUCCESS_200,
                Response = null
            });
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult> DeleteMyAccount(UserModel.DeleteMyAccountModel deleteMyAccountModel){
            await _userBusiness.DeleteUser(deleteMyAccountModel);
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageDelete,
                Code = CodeConstants.DELETE_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ChangePassword(UserModel.ChangePasswordUIModel changePasswordUIModel){
            await _userBusiness.ChangePassword(changePasswordUIModel);
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageUpdate,
                Code = CodeConstants.UPDATE_SUCCESS_200,
                Response = null
            });
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult> GetSubscription(UserModel.GetSubscriptionModel getSubscriptionModel){
            await _userBusiness.GetSubscription(getSubscriptionModel);
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageSave,
                Code = CodeConstants.INSERT_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GetBorrowedBooks(){
            var response = await _userBusiness.GetBorrowedBooks();
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