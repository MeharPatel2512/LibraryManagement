using System.ComponentModel.DataAnnotations;

namespace Library.Models.Request
{
    public class LoginUserModel
    {
        public class LoginUserUIModel{
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
        public class LoginUserDBModel{
            public string Email { get; set; }
        }
        public class TokenGenerationModel{
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }
    }
}