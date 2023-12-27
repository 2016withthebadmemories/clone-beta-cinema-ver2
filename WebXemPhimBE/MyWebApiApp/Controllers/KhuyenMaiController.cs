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
        public async Task<IEnumerable<KhuyenMai>> GetAllKhuyenMai()
        {
            return await _dbContext.KhuyenMais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<KhuyenMai> GetKhuyenMaiById(int id)
        {
            return await _dbContext.KhuyenMais.FindAsync(id);
        }

        [HttpPost]
        public async Task AddKhuyenMai(KhuyenMaiModel input)
        {
            var km = new KhuyenMai
            {
                MaKhuyenMai = input.MaKhuyenMai,
                ChuDe = input.ChuDe,
                NoiDung = input.NoiDung,
                NgayBatDau = input.NgayBatDau,
                NgayKetThuc = input.NgayKetThuc,
                AnhKhuyenMai = input.AnhKhuyenMai,
                MaPhim = input.MaPhim,
            };
            await _dbContext.AddAsync(km);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateKhuyenMai(KhuyenMai km)
        {
            _dbContext.Entry(km).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteKhuyenMai(int id)
        {
            var kmId = _dbContext.KhuyenMais.Where(x => x.MaKhuyenMai == id).FirstOrDefault();
            _dbContext.KhuyenMais.Remove(kmId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
