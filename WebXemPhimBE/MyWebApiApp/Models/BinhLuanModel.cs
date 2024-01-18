using MyWebApiApp.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Models
{
    public class BinhLuanModel
    {
        public int MaBinhLuan { get; set; }

        public string NoiDung { get; set; }

        public int MaTaiKhoan { get; set; }

        public string TenPhim{ get; set; }

        public string Email { get; set; }
        
        public string AnhDaiDien {  get; set; }

        public int MaPhim { get; set; }

        public DateTime NgayBinhLuan { get; set; }
    }
}
