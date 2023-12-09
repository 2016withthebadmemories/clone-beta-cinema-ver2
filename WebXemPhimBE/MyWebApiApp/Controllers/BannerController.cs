using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Banner>> GetAllBinhLuan()
        {
            return await _dbContext.Banners.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Banner> GetBinhLuanById(int id)
        {
            return await _dbContext.Banners.FindAsync(id);
        }

        [HttpPost]
        public async Task AddBinhLuan(BannerModel input)
        {
            var comment = new Banner
            {
                MaBanner = input.MaBanner,
                Ten = input.Ten,
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateBinhLuan(Banner comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteBinhLuan(int id)
        {
            var commentId = _dbContext.Banners.Where(x => x.MaBanner == id).FirstOrDefault();
            _dbContext.Banners.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
