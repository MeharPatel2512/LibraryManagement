using System.ComponentModel.DataAnnotations;
using Library.Utility.Attributes.EnumTypes;

namespace Library.Models.Request
{
    public class UserModel{

        public class UserMainModel{
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public bool Has_subscription { get; set; }
        }
        public class UpdateUserDataModel{
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
            // [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits")]
            public long Mobile { get; set; }
            public string ?Address { get; set; }
        }
        public class DeleteMyAccountModel{
            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
        public class ChangePasswordUIModel{
            [Required(ErrorMessage = "Password is required")]
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmNewPassword { get; set; }
        }
        public class ChangePasswordDBModel{
            public string NewPassword { get; set; }
        }
        public class GetSubscriptionModel
        {
            public int SubscriptionTypeId { get; set; }
            public DateOnly StartDate { get; set; }
        }
    }
}