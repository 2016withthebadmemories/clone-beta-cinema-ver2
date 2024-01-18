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
    public class GheController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public GheController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<GheModel>> GetAllGhe()
        {
            var result = await _dbContext.Ghes
                .Include(g => g.Phong)
                .Select(g => new GheModel
                {
                    MaGhe = g.MaGhe,
                    TenGhe = g.TenGhe,
                    MaPhong = g.MaPhong,
                    Cot = g.Cot,
                    Hang = g.Hang,
                    TenPhong = g.Phong.TenPhong,
                    TinhTrangGhe = g.TinhTrangGhe
                })
                .ToListAsync();

            return result;
        }

        [HttpGet("maPhong={maPhong}")]
        public async Task<IEnumerable<GheModel>> GetAllGhe(int? maPhong)
        {
            var query = _dbContext.Ghes
                .Include(g => g.Phong)
                .Select(g => new GheModel
                {
                    MaGhe = g.MaGhe,
                    TenGhe = g.TenGhe,
                    MaPhong = g.MaPhong,
                    Cot = g.Cot,
                    Hang = g.Hang,
                    TenPhong = g.Phong.TenPhong,
                    TinhTrangGhe = g.TinhTrangGhe
                });

            if (maPhong.HasValue)
            {
                query = query.Where(g => g.MaPhong == maPhong);
            }

            var result = await query.ToListAsync();

            return result;
        }



        [HttpGet("{id}")]
        public async Task<Ghe> GetGheById(int id)
        {
            return await _dbContext.Ghes.FindAsync(id);
        }

        [HttpPost("getGhe")]
        public async Task<IEnumerable<GheInfo>> GetGheByPhongId(InputGetGhe input)
        {
            var gheIdsDaDat = await _dbContext.Ves
                .Where(x => x.MaXuatChieu == input.MaXuatChieu)
                .Select(x => x.MaGhe)
                .ToListAsync();

            var listGhe = await _dbContext.Ghes
                .Where(x => x.MaPhong == input.MaPhong)
                .ToListAsync();

            var result = listGhe.Select(ghe => new GheInfo
            {
                MaGhe = ghe.MaGhe,
                TenGhe = ghe.TenGhe,
                TinhTrangGhe = ghe.TinhTrangGhe,
                TrangThai = gheIdsDaDat.Contains(ghe.MaGhe)
            });
            return result;
        }


        [HttpPost]
        public async Task AddGhe(GheModel input)
        {
            var sk = new Ghe
            {
                MaGhe = input.MaGhe,
                TenGhe = input.TenGhe,
                TinhTrangGhe = input.TinhTrangGhe,
                Cot = input.Cot,
                Hang = input.Hang,
                MaPhong = input.MaPhong,
            };

            await _dbContext.AddAsync(sk);
            await _dbContext.SaveChangesAsync();

            var phong = await _dbContext.Phongs.FindAsync(input.MaPhong);
            if (phong != null)
            {
                phong.SoLuongGhe++;
                await _dbContext.SaveChangesAsync();
            }
        }

        [HttpPut]
        public async Task UpdateGhe(Ghe sk)
        {
            _dbContext.Entry(sk).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteGhe(int id)
        {
            var gheToDelete = await _dbContext.Ghes.FindAsync(id);

            if (gheToDelete != null)
            {
                int maPhong = gheToDelete.MaPhong;

                var phong = await _dbContext.Phongs.FindAsync(maPhong);
                if (phong != null && phong.SoLuongGhe > 0)
                {
                    phong.SoLuongGhe--;
                }

                _dbContext.Ghes.Remove(gheToDelete);

                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
