using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class XuatChieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaXuatChieu { get; set; }

        public DateTime NgayChieu { get; set; }

        public int Gio { get; set; }

        public int Phut { get; set; }

        public int MaPhim { get; set; }
        [ForeignKey(nameof(MaPhim))]
        public Phim Phim { get; set; }
    }
}
