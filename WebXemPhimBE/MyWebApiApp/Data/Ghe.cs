using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public class Ghe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGhe { get; set; }

        public string TenGhe { get; set; }

        public bool TinhTrangGhe { get; set; }

        public int Cot {  get; set; }

        public int Hang { get; set; }

        public int MaPhong {  get; set; }
        [ForeignKey(nameof(MaPhong))]
        public Phong Phong { get; set; }
    }
}
