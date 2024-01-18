using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace MyWebApiApp.Models
{
    public class DatVeModel
    {
        public int MaDatVe { get; set; }

        public int SoLuong { get; set; }

        public float TongGia { get; set; }

        public DateTime NgayDatVe { get; set; }

        public int MaTaiKhoan { get; set; }
    }

    public class VeModel {
        public int MaVe { get; set; }

        public int MaDatVe { get; set; }

        public int MaXuaChieu { get; set; }

        public int MaGhe { get; set; }
    }

    public class DatVePro
    {
        public int MaXuatChieu { get; set; }
        public int MaTaiKhoan { get; set; }
        public List<int> MaGhes { get; set; }
        public int SoLuong { get; set; }
        public float TongGia { get; set; }
    }

    public class DatVeInfo
    {
        public int SoLuong { get; set; }
        public float TongGia { get; set; }
        public DateTime NgayDatVe { get; set; }
        public int MaDatVe { get; set; }
        public string Email { get; set; }
        public XuatChieuInfo XuatChieu { get; set; }
        public List<GheVe> Ghes { get; set; }
    }

    public class XuatChieuInfo
    {
        public int MaXuatChieu { get; set; }
        public int Gio { get; set; }
        public int Phut { get; set; }
        public string TenPhong { get; set; }
        public string TenRap { get; set; }
        public string TenPhim { get; set; }
    }
    public class GheVe
    {
        public int MaGhe { get; set; }
        public string TenGhe { get; set; }
    }


}
