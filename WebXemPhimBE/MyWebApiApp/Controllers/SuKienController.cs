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
        public async Task<IEnumerable<SuKien>> GetAllSuKien()
        {
            return await _dbContext.SuKiens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<SuKien> GetSuKienById(int id)
        {
            return await _dbContext.SuKiens.FindAsync(id);
        }

        [HttpPost]
        public async Task AddSuKien(SuKienModel input)
        {
            var sk = new SuKien
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
            await _dbContext.AddAsync(sk);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateSuKien(SuKien sk)
        {
            _dbContext.Entry(sk).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteSuKien(int id)
        {
            var skId = _dbContext.SuKiens.Where(x => x.MaSuKien == id).FirstOrDefault();
            _dbContext.SuKiens.Remove(skId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
