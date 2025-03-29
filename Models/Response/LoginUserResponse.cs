using System.ComponentModel.DataAnnotations;

namespace Library.Models.Response{
    public class LoginUserResponse{
        public int ?UserId { get; set; }
        public string ?Email { get; set; }
        public string ?Role { get; set; }
        public string ?Token { get; set; }
        public int Expirytime { get; set; }
    }
}