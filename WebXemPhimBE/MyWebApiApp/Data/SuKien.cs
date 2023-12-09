using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class SuKien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSuKien { get; set; }

        public string TenSuKien { get; set; }

        public DateTime NgayDang { get; set; }

        public string AnhSuKien { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc {  get; set; }

        public string NoiDung {  get; set; }

        public int MaRap {  get; set; }
        [ForeignKey(nameof(MaRap))]
        public KhuyenMai Rap { get; set; }
    }
}
