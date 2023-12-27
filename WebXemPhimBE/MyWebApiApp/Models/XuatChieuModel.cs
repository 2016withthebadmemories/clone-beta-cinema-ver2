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

    }

    public class XuatChieuRequestModel
    {
        public int Ngay { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int MaPhim { get; set; }
    }
}
