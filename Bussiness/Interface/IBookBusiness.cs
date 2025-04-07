using System.Data;
using Library.Models.Request;

namespace Library.Business.Interface
{
    public interface IBookBusiness
    {
        Task<Boolean> AddNewBook(BookModel.AddNewBookModel addNewBookModel);
        Task<Boolean> UpdateBookDetails(BookModel.UpdateBookDetailsModel updateBookDetailsModel);
        Task<Boolean> DeleteBook(BookModel.DeleteBookModel deleteBookModel);
        Task<DataSet> GetBooks(BookModel.GetBooksModel getBooksModel);
        Task<Boolean> BorrowBook(BookModel.BorrowBookUIModel borrowBookUIModel);
        Task<Boolean> ReturnBook(BookModel.ReturnBookModel returnBookModel);
        Task<DataSet> CheckAvailability(BookModel.CheckAvailabilityModel checkAvailabilityModel);
        Task<DataSet> GetBookHistory(BookModel.GetBookHistoryModel getBookHistoryModel);
        // Task BorrowBook(BookModel.BorrowBookModel borrowBookModel);
        // Task<DataSet> GetBorrowedBooks(BookModel.GetBorrowedBooksModel getBorrowedBooksModel);
        // Task<DataSet> SearchBooks(BookModel.SearchBooksModel searchBooksModel);
    }
}