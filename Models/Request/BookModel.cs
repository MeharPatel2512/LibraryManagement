using System.ComponentModel.DataAnnotations;

namespace Library.Models.Request
{
    public class BookModel{
        public class AddNewBookModel{
            [Required(ErrorMessage = "Book Title is required")]
            public string Title { get; set;} 

            [Required(ErrorMessage = "Author Name is required")]
            public string Author { get; set;} 

            [Required(ErrorMessage = "ISBN number is required")]
            public string ISBN { get; set;} 

            [Required(ErrorMessage = "Publisher is required")]
            public string Publisher { get; set;} 

            [Required(ErrorMessage = "Published Year is required")]
            [Range(1500, 2025, ErrorMessage = "Published Year must be between 1900 and 2100")]
            public int PublishedYear { get; set;} 

            [Required(ErrorMessage = "Category is required")]
            public string Category { get; set;} 

            [Required(ErrorMessage = "Description is required")]
            public string Description { get; set;} 

            [Required(ErrorMessage = "Total number of copies is required")]
            public int TotalCopies { get; set;}
        }

        public class UpdateBookDetailsModel{
            [Required(ErrorMessage = "Book Id is required")]
            public int BookId { get; set; }

            [Required(ErrorMessage = "Book Title is required")]
            public string Title { get; set;} 

            [Required(ErrorMessage = "Author Name is required")]
            public string Author { get; set;} 

            [Required(ErrorMessage = "ISBN number is required")]
            public string ISBN { get; set;} 

            [Required(ErrorMessage = "Publisher is required")]
            public string Publisher { get; set;} 

            [Required(ErrorMessage = "Published Year is required")]
            [Range(1500, 2025, ErrorMessage = "Published Year must be between 1900 and 2100")]
            public int PublishedYear { get; set;} 

            [Required(ErrorMessage = "Category is required")]
            public string Category { get; set;} 

            [Required(ErrorMessage = "Description is required")]
            public string Description { get; set;} 

            [Required(ErrorMessage = "Total number of copies is required")]
            public int TotalCopies { get; set;} 

            [Required(ErrorMessage = "Available number of copies is required")]
            public int AvailableCopies { get; set;} 
        }

        public class UpsertBookModel{
            public int BookId { get; set; }
            public string Title { get; set;} 
            public string Author { get; set;} 
            public string ISBN { get; set;} 
            public string Publisher { get; set;} 
            public int PublishedYear { get; set;} 
            public string Category { get; set;} 
            public string Description { get; set;} 
            public int TotalCopies { get; set;} 
            public int AvailableCopies { get; set;} 
            public DateOnly ?NextAvailableDate { get; set;} 
            public DateTime UpdatedAt { get; set;}
        }

        public class DeleteBookModel{
            [Required(ErrorMessage = "BookId is required")]
            public int BookId { get; set; }

            [Required(ErrorMessage = "ISBBN number is required")]
            public string ISBN { get; set; }
        }

        public class GetBooksModel{
            public int BookId { get; set; }
            public string ?ISBN { get; set; }
        }

        public class BorrowBookUIModel{
            [Required(ErrorMessage = "BookId is required")]
            public int BookId { get; set; } 
        }

        public class BorrowBookDBModel{
            [Required(ErrorMessage = "BookId is required")]
            public int BookId { get; set; } 
            public DateOnly BorrowDate { get; set; }
        }

        public class ReturnBookModel{
            [Required(ErrorMessage = "BookId is required")]
            public int BookId { get; set; } 
        }
        public class ReturnBookDBModel{
            public int BookId { get; set; } 
            public DateOnly ReturnDate { get; set; }
        }
    }
}