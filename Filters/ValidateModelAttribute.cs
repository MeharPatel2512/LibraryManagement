using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Library.Models.Response;
using Library.Utility.Constants;

namespace Library.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {            
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var response = new ApiResponse
                {
                    Error_status = true,
                    Message = MessageConstants.InvalidRequest,
                    Code = CodeConstants.INVALID_REQUEST,
                    Response = errors
                };

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
