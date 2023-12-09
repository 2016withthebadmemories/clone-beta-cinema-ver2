using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyWebApiApp.Models
{
    public class SuKienModel
    {
        public int MaSuKien { get; set; }

        public string TenSuKien { get; set; }

        public DateTime NgayDang { get; set; }

        public string AnhSuKien { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string NoiDung { get; set; }

        public int MaRap { get; set; }
    }
}
