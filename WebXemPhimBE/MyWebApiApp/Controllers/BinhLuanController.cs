using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MyWebApiApp.Models;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public BinhLuanController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<List<BinhLuanModel>> GetBinhLuanOfPhim()
        {
            return await _dbContext.BinhLuans
                .Join(_dbContext.TaiKhoans,
                        binhLuan => binhLuan.MaTaiKhoan, nguoiBinhLuan =>
                        nguoiBinhLuan.MaTaiKhoan, (binhLuan, nguoiBinhLuan) => new
                        {
                            BinhLuan = binhLuan,
                            ThongTinNguoiDung = nguoiBinhLuan
                        })
                .Join(_dbContext.Phims,
                        joined => joined.BinhLuan.MaPhim, phim => phim.MaPhim, (joined, phim) => new
                        {
                            joined.BinhLuan,
                            joined.ThongTinNguoiDung,
                            phim.TenPhim
                        })
                .Select(result => new BinhLuanModel
                {
                    MaBinhLuan = result.BinhLuan.MaBinhLuan,
                    Email = result.ThongTinNguoiDung.Email,
                    AnhDaiDien = result.ThongTinNguoiDung.AnhDaiDien,
                    NoiDung = result.BinhLuan.NoiDung,
                    NgayBinhLuan = result.BinhLuan.NgayBinhLuan,
                    TenPhim = result.TenPhim
                })
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<BinhLuan> GetBinhLuanById(int id)
        {
            return await _dbContext.BinhLuans.FindAsync(id);
        }

        [HttpPost]
        public async Task AddBinhLuan(BinhLuanModel input)
        {
            DateTime date = DateTime.Now;
            var comment = new BinhLuan
            {
                MaBinhLuan = input.MaBinhLuan,
                NoiDung = input.NoiDung,
                MaTaiKhoan = input.MaTaiKhoan,
                MaPhim = input.MaPhim,
                NgayBinhLuan = date
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateBinhLuan(BinhLuan comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteBinhLuan(int id)
        {
            var commentId = _dbContext.BinhLuans.Where(x => x.MaBinhLuan == id).FirstOrDefault();
            _dbContext.BinhLuans.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
