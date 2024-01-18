using Microsoft.AspNetCore.Http;

namespace MyWebApiApp.Models
{
    public class BannerModel { 
        public IFormFile Anh { get; set; }
    }

    public class EditBannerModel
    {
        public int MaBanner { get; set; }
        public IFormFile Anh { get; set; }
    }
}
