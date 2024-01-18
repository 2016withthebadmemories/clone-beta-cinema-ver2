using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class Ve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaVe { get; set; }

        public int MaDatVe {get; set; }
        [ForeignKey(nameof(MaDatVe))]
        public DatVe DatVe { get; set; }

        public int MaXuatChieu { get; set; }
        [ForeignKey(nameof(MaXuatChieu))]
        public XuatChieu XuatChieu { get; set; }

        public int MaGhe { get; set; }
        [ForeignKey(nameof(MaGhe))]
        public Ghe Ghe { get; set; }
    }
}
