using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class DatVe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDatVe { get; set; }

        public int SoLuong { get; set; }

        public float TongGia {  get; set; }

        public DateTime NgayDatVe { get; set; }

        public int MaTaiKhoan { get; set; }
        [ForeignKey(nameof(MaTaiKhoan))]
        public TaiKhoan TaiKhoan { get; set; }
    }
}
