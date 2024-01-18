using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Models
{
    public class GheModel
    {
        public int MaGhe { get; set; }

        public string TenGhe { get; set; }

        public bool TinhTrangGhe { get; set; }

        public int Cot { get; set; }

        public int Hang { get; set; }

        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
    }

    public class InputGetGhe
    {
        public int MaXuatChieu { get; set; }
        public int MaPhong { get; set; }

    }

    public class GheInfo
    {
        public int MaGhe { get; set; }
        public bool TinhTrangGhe { get; set; }

        public string TenGhe { get; set; }
        public bool TrangThai { get; set; }
    }
}
