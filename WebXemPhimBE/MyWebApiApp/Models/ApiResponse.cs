using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string MatKhau { get; set; }
    }

    public class ChangePasswordModel
    {
        public int MaTaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}
