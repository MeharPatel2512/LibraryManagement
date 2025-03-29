using System.ComponentModel.DataAnnotations;

namespace Library.Models.Request
{
    public class RegisterUserModel
    {
        public class RegisterUserUIModel{

            [Required(ErrorMessage = "First Name is required")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Last Name is required")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Mobile number is required")]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits")]
            public long Mobile { get; set; }
            public string ?Address { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
        public class RegisterUserDBModel{
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public long Mobile { get; set; }
            public string Address { get; set; }
            public string Role { get; set; }
            public bool HasSubscription { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}