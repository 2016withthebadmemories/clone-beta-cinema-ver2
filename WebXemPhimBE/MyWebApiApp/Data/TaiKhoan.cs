using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string AnhDaiDien {  get; set; }

        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public DateTime NgaySinh { get; set; }

        public bool LoaiTaiKhoan { get; set; }
    }
}
