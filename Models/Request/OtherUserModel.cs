using System.ComponentModel.DataAnnotations;

namespace Library.Models.Request
{
    public class OtherUserModel{

        public class GetProfileModel{
            [Required(ErrorMessage = "UserId is required")]
            public int UserId { get; set; }
        }
    }
}