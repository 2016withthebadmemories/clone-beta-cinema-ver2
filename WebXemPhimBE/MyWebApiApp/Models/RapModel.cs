using MyWebApiApp.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Models
{
    public class RapModel
    {
        public int MaRap { get; set; }

        public string TenRap { get; set; }

        public string DiaChi { get; set; }

        public int MaTaiKhoan { get; set; }
    }
}
