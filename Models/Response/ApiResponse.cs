using System.ComponentModel.DataAnnotations;

namespace Library.Models.Response{
    public class ApiResponse{
        public string ?Message { get; set; }
        [Required]
        public string ?Code { get; set; }
        [Required]
        public bool Error_status { get; set; }
        public object? Response { get; set; }
    }
}