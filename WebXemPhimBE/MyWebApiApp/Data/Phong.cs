using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class Phong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhong { get; set; } 

        public string TenPhong { get; set; }

        public bool TrangThai { get; set; }

        public string GhiChu { get; set; }

        public int SoLuongGhe { get; set; }

        public int MaXuatChieu { get; set; }
        [ForeignKey(nameof(MaXuatChieu))]
        public XuatChieu XuatChieu { get; set; }
    }
}
