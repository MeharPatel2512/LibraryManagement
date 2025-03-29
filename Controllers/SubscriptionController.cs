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
    [Route("api/subscription")]
    // [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorInfo))]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionBusiness _subscriptionBusiness;

        public SubscriptionController(ISubscriptionBusiness subscriptionBusiness){
            _subscriptionBusiness = subscriptionBusiness;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GetSubscription(){
            var response = await _subscriptionBusiness.GetSubscriptionTypes();
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageList,
                Code = CodeConstants.GET_DATA_SUCCESSFUL_200,
                Response = response
            });
        }
    }
}