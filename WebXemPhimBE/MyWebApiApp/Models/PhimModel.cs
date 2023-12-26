using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyWebApiApp.Models
{
    public class PhimModel
    {
        public int MaPhim { get; set; }

        public string TenPhim { get; set; }

        public string MoTa { get; set; }

        public string DienVien { get; set; }

        public string Daodien { get; set; }

        public float Gia { get; set; }

        public string AnhPhim { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string QuocGia { get; set; }

        public string HangPhim { get; set; }

        public string PhienBan { get; set; }

        public string TheLoai { get; set; }

        public bool TrangThai { get; set; }

        public string ThoiLuong { get; set; }

        public int MaRap { get; set; }
    }
}
