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
    public class KhuyenMaiController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public KhuyenMaiController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<KhuyenMai>> GetAllBinhLuan()
        {
            return await _dbContext.KhuyenMais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<KhuyenMai> GetBinhLuanById(int id)
        {
            return await _dbContext.KhuyenMais.FindAsync(id);
        }

        [HttpPost]
        public async Task AddBinhLuan(KhuyenMaiModel input)
        {
            var comment = new KhuyenMai
            {
                MaKhuyenMai = input.MaKhuyenMai,
                ChuDe = input.ChuDe,
                NoiDung = input.NoiDung,
                NgayBatDau = input.NgayBatDau,
                NgayKetThuc = input.NgayKetThuc,
                AnhKhuyenMai = input.AnhKhuyenMai,
                MaPhim = input.MaPhim,
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateBinhLuan(KhuyenMai comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteBinhLuan(int id)
        {
            var commentId = _dbContext.KhuyenMais.Where(x => x.MaKhuyenMai == id).FirstOrDefault();
            _dbContext.KhuyenMais.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
