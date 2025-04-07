using Library.Business.Interface;
using Library.Models.Request;
using Library.Models.Response;
using Library.Utility.Config;
using Library.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    [Route("api/Book")]
    // [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ErrorInfo))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorInfo))]
    public class BookControoller : Controller{
        private readonly IBookBusiness _bookBusiness;

        public BookControoller(IBookBusiness bookBusiness){
            _bookBusiness = bookBusiness;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddNewBook(BookModel.AddNewBookModel addNewBookModel){
            await _bookBusiness.AddNewBook(addNewBookModel);

            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageSave,
                Code = CodeConstants.INSERT_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> UpdateBookdetails(BookModel.UpdateBookDetailsModel updateBookDetailsModel){
            await _bookBusiness.UpdateBookDetails(updateBookDetailsModel);

            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageUpdate,
                Code = CodeConstants.UPDATE_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> DeleteBook(BookModel.DeleteBookModel deleteBookModel){
            await _bookBusiness.DeleteBook(deleteBookModel);

            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageDelete,
                Code = CodeConstants.DELETE_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GetBooks(BookModel.GetBooksModel getBooksModel){
            var response = await _bookBusiness.GetBooks(getBooksModel);
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
        public async Task<ActionResult> BorrowBook(BookModel.BorrowBookUIModel borrowBookUIModel){
            await _bookBusiness.BorrowBook(borrowBookUIModel);
            
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageSave,
                Code = CodeConstants.INSERT_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> RetunBook(BookModel.ReturnBookModel returnBookModel){
            await _bookBusiness.ReturnBook(returnBookModel);
            
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageSave,
                Code = CodeConstants.INSERT_SUCCESS_200,
                Response = null
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CheckAvailability(BookModel.CheckAvailabilityModel checkAvailabilityModel){
            var response = await _bookBusiness.CheckAvailability(checkAvailabilityModel);
            
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageList,
                Code = CodeConstants.GET_DATA_SUCCESSFUL_200,
                Response = response
            });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GEtBookHistory(BookModel.GetBookHistoryModel getBookHistoryModel){
            var response = await _bookBusiness.GetBookHistory(getBookHistoryModel);
            
            return Ok(new ApiResponse{
                Error_status = false,
                Message = MessageConstants.SuccessMessageList,
                Code = CodeConstants.GET_DATA_SUCCESSFUL_200,
                Response = response
            });
        }

        // [HttpPost("[action]")]
        // public async Task<ActionResult> GetBorrowedBooks([FromBody] BookModel.GetBorrowedBooksModel getBorrowedBooksModel){
        //     var response = await _bookBusiness.GetBorrowedBooks(getBorrowedBooksModel);
        //     if(response != null) 
        //         return Ok(new ApiResponse{
        //             Error_status = false,
        //             Message = MessageConstants.SuccessMessageList,
        //             Code = CodeConstants.GET_DATA_SUCCESSFUL_200,
        //             Response = response
        //         });
        //     else 
        //     return Ok(new ApiResponse{
        //         Error_status = true,
        //         Message = MessageConstants.NoContent,
        //         Code = CodeConstants.GET_DATA_NO_DATA_FOUND_204,
        //         Response = null
        //     });
        // }

        // [HttpPost("[action]")]
        // public async Task<ActionResult> SearchBooks(BookModel.SearchBooksModel searchBooksModel){
        //     var response = await _bookBusiness.SearchBooks(searchBooksModel);
        //     if(response != null) 
        //         return Ok(new ApiResponse{
        //             Error_status = false,
        //             Message = MessageConstants.SuccessMessageList,
        //             Code = CodeConstants.GET_DATA_SUCCESSFUL_200,
        //             Response = response
        //         });
        //     else 
        //     return Ok(new ApiResponse{
        //         Error_status = true,
        //         Message = MessageConstants.NoContent,
        //         Code = CodeConstants.GET_DATA_NO_DATA_FOUND_204,
        //         Response = null
        //     });
        // }
    }
}