using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyWebApiApp.Data
{
    public class BinhLuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBinhLuan { get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayBinhLuan { get; set; }

        public int MaTaiKhoan { get; set; }
        [ForeignKey(nameof(MaTaiKhoan))]
        public TaiKhoan TaiKhoan { get; set; }
        public int MaPhim {  get; set; }
        [ForeignKey(nameof(MaPhim))]
        public Phim Phim { get; set; }
    }
}
