using Microsoft.AspNetCore.Http;
using System;

namespace MyWebApiApp.Models
{
    public class TaiKhoanModel
    {
        public int MaTaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string AnhDaiDien { get; set; }

        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public DateTime NgaySinh { get; set; }

        public bool LoaiTaiKhoan { get; set; }
        public IFormFile Anh { get; set; }
    }
}
