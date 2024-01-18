using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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

        public DateTime NgayTao { get; set; }

        public string LinkTrailer { get; set; }

        public string QuocGia { get; set; }

        public string HangPhim { get; set; }

        public string PhienBan { get; set; }

        public string TheLoai { get; set; }

        public bool TrangThai { get; set; }

        public string ThoiLuong { get; set; }

        public int MaRap { get; set; }

        public string TenRap { get; set; }

        public IFormFile AnhPhimFile { get; set; }

    }

    public class XuatChieuPhim
    {
        public string NgayChieu { get; set; }


        public string Gio { get; set; }
        public string Phut { get; set; }
    }

    public class RequestXuatChieu
    {
        public int MaPhim { get; set; }
        public int MaPhong { get; set; }

        public List<XuatChieuPhim> XuatChieus { get; set; }
    }

    public class UpdateXuatChieuRequest
    {
        public int MaXuatChieu { get; set; }
        public int Gio { get; set; }
        public int Phut { get; set; }
    }
}
