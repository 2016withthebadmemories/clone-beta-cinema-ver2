using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class Rap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaRap { get; set; }

        public string TenRap { get; set; }

        public string DiaChi { get; set; }

        public int? MaTaiKhoan { get; set; }
        [ForeignKey(nameof(MaTaiKhoan))]
        public TaiKhoan TaiKhoan { get; set; }
    }
}
