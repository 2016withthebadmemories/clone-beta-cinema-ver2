using System;

namespace MyWebApiApp.Models
{
    public class XuatChieuModel
    {
        public int MaXuatChieu { get; set; }

        public DateTime NgayChieu { get; set; }

        public int Gio { get; set; }

        public int Phut { get; set; }
        public int MaPhim { get; set; }
        public int MaPhong { get; set; }

    }

    public class XuatChieuRequestModel
    {
        public int MaXuatChieu { get; set; }

        public int Ngay { get; set; }
        public int Thang { get; set; }
        public DateTime NgayChieu { get; set; }
        public int Gio { get; set; }

        public int Phut { get; set; }

        public int Nam { get; set; }
        public int MaPhim { get; set; }
        public int MaPhong { get; set; }
        public string TenPhim { get; set; }
        public string TenRap { get; set; }
        public string TenPhong { get; set; }
    }
}
