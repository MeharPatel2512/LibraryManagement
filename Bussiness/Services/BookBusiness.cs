using System.Data;
using Library.Business.Interface;
using Library.Models.Request;
using Library.Repository;
using Library.Utility.DBConstants;

namespace Library.Business.Services
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IExecuteStoredProcedure _executeStoredProcedure;

        public BookBusiness(IExecuteStoredProcedure executeStoredProcedure){
            _executeStoredProcedure = executeStoredProcedure;
        }

        public async Task<Boolean> AddNewBook(BookModel.AddNewBookModel addNewBookModel){
            BookModel.UpsertBookModel book = new BookModel.UpsertBookModel{
                BookId = 0,
                Title = addNewBookModel.Title,
                Author = addNewBookModel.Author,
                ISBN = addNewBookModel.ISBN,
                Publisher = addNewBookModel.Publisher,
                PublishedYear = addNewBookModel.PublishedYear,
                Category = addNewBookModel.Category,
                Description = addNewBookModel.Description,
                TotalCopies = addNewBookModel.TotalCopies,
                AvailableCopies = addNewBookModel.TotalCopies,
                NextAvailableDate = null,
                UpdatedAt = DateTime.Now
            };

            return await _executeStoredProcedure.CallNonQueryStoredProcedure<BookModel.UpsertBookModel>(StoredProcedureConstants.UPSERT_BOOK, book, true);
        }

        public async Task<Boolean> UpdateBookDetails(BookModel.UpdateBookDetailsModel updateBookDetailsModel){
            BookModel.UpsertBookModel book = new BookModel.UpsertBookModel{
                BookId = updateBookDetailsModel.BookId,
                Title = updateBookDetailsModel.Title,
                Author = updateBookDetailsModel.Author,
                ISBN = updateBookDetailsModel.ISBN,
                Publisher = updateBookDetailsModel.Publisher,
                PublishedYear = updateBookDetailsModel.PublishedYear,
                Category = updateBookDetailsModel.Category,
                Description = updateBookDetailsModel.Description,
                TotalCopies = updateBookDetailsModel.TotalCopies,
                AvailableCopies = updateBookDetailsModel.AvailableCopies,
                NextAvailableDate = null,
                UpdatedAt = DateTime.Now
            };

            return await _executeStoredProcedure.CallNonQueryStoredProcedure<BookModel.UpsertBookModel>(StoredProcedureConstants.UPSERT_BOOK, book, true);
        }

        public async Task<Boolean> DeleteBook(BookModel.DeleteBookModel deleteBookModel){

            return await _executeStoredProcedure.CallNonQueryStoredProcedure<BookModel.DeleteBookModel>(StoredProcedureConstants.UPSERT_BOOK, deleteBookModel, true);
        }

        public async Task<DataSet> GetBooks(BookModel.GetBooksModel getBooksModel){

            DataSet ds = new DataSet();
            
            ds = await _executeStoredProcedure.CallStoredProcedure<BookModel.GetBooksModel>(StoredProcedureConstants.GET_BOOKS, getBooksModel, false);

            return ds;
        }

        public async Task<Boolean> BorrowBook(BookModel.BorrowBookUIModel borrowBookUIModel){

            BookModel.BorrowBookDBModel book = new BookModel.BorrowBookDBModel{
                BookId = borrowBookUIModel.BookId,
                BorrowDate = DateOnly.FromDateTime(DateTime.Now)
            };
            return await _executeStoredProcedure.CallNonQueryStoredProcedure<BookModel.BorrowBookDBModel>(StoredProcedureConstants.BORROW_A_BOOK, book, true);
        }

        public async Task<Boolean> ReturnBook(BookModel.ReturnBookModel returnBookModel){

            BookModel.ReturnBookDBModel book = new BookModel.ReturnBookDBModel{
                BookId = returnBookModel.BookId,
                ReturnDate = DateOnly.FromDateTime(DateTime.Now)
            };

            return await _executeStoredProcedure.CallNonQueryStoredProcedure<BookModel.ReturnBookDBModel>(StoredProcedureConstants.RETURN_BOOK, book, true);
        }

        // public async Task<DataSet> GetBorrowedBooks(BookModel.GetBorrowedBooksModel getBorrowedBooksModel)
        // {
        //     DataSet ds = new DataSet();

        //     ds = await _executeStoredProcedure.CallStoredProcedure<BookModel.GetBorrowedBooksModel>(StoredProcedureConstants.GET_BORROWED_BOOKS, getBorrowedBooksModel, false);

        //     return ds;
        // }

        // public async Task<DataSet> SearchBooks(BookModel.SearchBooksModel searchBooksModel){

        //     Console.WriteLine(searchBooksModel.BookId);
        //     Console.WriteLine(searchBooksModel.BookName);
        //     Console.WriteLine(searchBooksModel.Author);
        //     Console.WriteLine(searchBooksModel.FromDate);
        //     Console.WriteLine(searchBooksModel.ToDate);
        //     Console.WriteLine(searchBooksModel.Month);
        //     Console.WriteLine(searchBooksModel.Year);

        //     DataSet ds = new DataSet();

        //     ds = await _executeStoredProcedure.CallStoredProcedure<BookModel.SearchBooksModel>(StoredProcedureConstants.SEARCH_BOOKS, searchBooksModel, false);

        //     return ds;
        // }
    }
}