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
    public class PhongController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public PhongController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Phong>> GetAllPhong()
        {
            return await _dbContext.Phongs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Phong> GetPhongById(int id)
        {
            return await _dbContext.Phongs.FindAsync(id);
        }

        [HttpPost]
        public async Task AddPhong(PhongModel input)
        {
            var sk = new Phong
            {
                MaPhong = input.MaPhong,
                TenPhong = input.TenPhong,
                TrangThai = input.TrangThai,
                GhiChu = input.GhiChu,
                SoLuongGhe = input.SoLuongGhe,
            };
            await _dbContext.AddAsync(sk);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateSuKien(Phong sk)
        {
            _dbContext.Entry(sk).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeletePhong(int id)
        {
            var skId = _dbContext.Phongs.Where(x => x.MaPhong == id).FirstOrDefault();
            _dbContext.Phongs.Remove(skId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
