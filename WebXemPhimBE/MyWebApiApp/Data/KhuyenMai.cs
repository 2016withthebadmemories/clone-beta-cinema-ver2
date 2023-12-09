using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class KhuyenMai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhuyenMai { get; set; }

        public string ChuDe {  get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc {  get; set; }

        public string AnhKhuyenMai { get; set; }

        public int MaPhim { get; set; }
        [ForeignKey(nameof(MaPhim))]
        public Phim Phim { get; set; }
    }
}
