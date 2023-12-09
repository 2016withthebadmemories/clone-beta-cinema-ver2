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
    public class SuKienController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public SuKienController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<SuKien>> GetAllBinhLuan()
        {
            return await _dbContext.SuKiens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<SuKien> GetBinhLuanById(int id)
        {
            return await _dbContext.SuKiens.FindAsync(id);
        }

        [HttpPost]
        public async Task AddBinhLuan(SuKienModel input)
        {
            var comment = new SuKien
            {
                MaSuKien = input.MaSuKien,
                TenSuKien = input.TenSuKien,
                NgayDang = input.NgayDang,
                AnhSuKien = input.AnhSuKien,
                NgayBatDau = input.NgayBatDau,
                NgayKetThuc = input.NgayKetThuc,
                NoiDung = input.NoiDung,
                MaRap = input.MaRap,
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateBinhLuan(SuKien comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteBinhLuan(int id)
        {
            var commentId = _dbContext.SuKiens.Where(x => x.MaSuKien == id).FirstOrDefault();
            _dbContext.SuKiens.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
