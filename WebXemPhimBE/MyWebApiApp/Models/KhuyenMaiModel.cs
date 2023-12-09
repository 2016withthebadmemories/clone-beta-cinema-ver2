using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyWebApiApp.Models
{
    public class KhuyenMaiModel
    {
        public int MaKhuyenMai { get; set; }

        public string ChuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string AnhKhuyenMai { get; set; }

        public int MaPhim { get; set; }
    }
}
