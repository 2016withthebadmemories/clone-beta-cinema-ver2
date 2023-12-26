using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public BannerController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Banner>> GetAllBanner()
        {
            return await _dbContext.Banners.ToListAsync();
        }

        [HttpPost]
        public async Task AddBanner([FromForm] BannerModel input)
        {
            var path = Path.Combine("wwwroot/images", input.Anh.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await input.Anh.CopyToAsync(stream);
            }
            var banner = new Banner
            {
                Ten = $"{this.Request.Scheme}://{this.Request.Host}/images/{input.Anh.FileName}"
            };
            _dbContext.Banners.Add(banner);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteBanner(int id)
        {
            var commentId = _dbContext.Banners.Where(x => x.MaBanner == id).FirstOrDefault();
            _dbContext.Banners.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
