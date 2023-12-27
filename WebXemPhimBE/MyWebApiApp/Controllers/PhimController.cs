using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
    public class PhimController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public PhimController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Phim>> GetAllDistinctPhimNames()
        {
            var distinctPhimNames = await _dbContext.Phims
                                                    .Select(p => p.TenPhim)
                                                    .Distinct()
                                                    .Select(tenPhim => _dbContext.Phims.First(p => p.TenPhim == tenPhim))
                                                    .ToListAsync();

            return distinctPhimNames;
        }


        [HttpGet("tenRap={tenRap}")]
        public async Task<IEnumerable<Phim>> GetAllPhimByRap(string tenRap = null)
        {
            if (string.IsNullOrEmpty(tenRap))
            {
                var distinctPhimNames = await _dbContext.Phims
                                                      .Select(p => p.TenPhim)
                                                      .Distinct()
                                                      .Select(tenPhim => _dbContext.Phims.First(p => p.TenPhim == tenPhim))
                                                      .ToListAsync();

                return distinctPhimNames;
            }
            else
            {
                var rapDetail = _dbContext.Raps.Where(x => x.TenRap == tenRap).FirstOrDefault();
                return await _dbContext.Phims.Where(x => x.MaRap == rapDetail.MaRap).ToListAsync();
            }
        }


        [HttpGet("{id}")]
        public async Task<Phim> GetPhimById(int id)
        {
            return await _dbContext.Phims.FindAsync(id);
        }

        [HttpPost]
        public async Task AddPhim(PhimModel input)
        {
            var phim = new Phim
            {
                MaPhim = input.MaPhim,
                TenPhim = input.TenPhim,
                MoTa = input.MoTa,
                DienVien = input.DienVien,
                Daodien = input.Daodien,
                Gia = input.Gia,
                AnhPhim = input.AnhPhim,
                NgayBatDau = input.NgayBatDau,
                NgayKetThuc = input.NgayKetThuc,
                QuocGia = input.QuocGia,
                HangPhim = input.HangPhim,
                PhienBan = input.PhienBan,
                TheLoai = input.TheLoai,
                TrangThai = input.TrangThai,
                MaRap = input.MaRap,
                ThoiLuong = input.ThoiLuong,

            };
            await _dbContext.AddAsync(phim);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdatePhim(Phim phim)
        {
            _dbContext.Entry(phim).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeletePhim(int id)
        {
            var phimId = _dbContext.Phims.Where(x => x.MaPhim == id).FirstOrDefault();
            _dbContext.Phims.Remove(phimId);
            await _dbContext.SaveChangesAsync();
        }

        [HttpGet("postId={postId}")]
        public async Task<List<BinhLuanModel>> GetBinhLuanOfPhim(int postId)
        {
            return await _dbContext.BinhLuans.Where(binhLuan => binhLuan.MaPhim == postId)
                .Join(_dbContext.TaiKhoans,
                        binhLuan => binhLuan.MaTaiKhoan, nguoiBinhLuan =>
                        nguoiBinhLuan.MaTaiKhoan, (binhLuan, nguoiBinhLuan) => new
                        {
                            BinhLuan = binhLuan,
                            ThongTinNguoiDung = nguoiBinhLuan
                        }).Select(result => new BinhLuanModel
                        {
                            Email = result.ThongTinNguoiDung.Email,
                            AnhDaiDien = result.ThongTinNguoiDung.AnhDaiDien,
                            NoiDung = result.BinhLuan.NoiDung,
                            NgayBinhLuan = result.BinhLuan.NgayBinhLuan,
                        })
                        .ToListAsync();
        }

        [HttpGet("search={text}")]
        public async Task<List<PhimModel>> SearchPhimBangTen(string text)
        {
            return await _dbContext.Phims.Where(x => x.TenPhim.Contains(text))
                .Select(x => new PhimModel
                {
                    MaPhim = x.MaPhim,
                    TenPhim = x.TenPhim,
                    MoTa = x.MoTa,
                    DienVien = x.DienVien,
                    Daodien = x.Daodien,
                    Gia = x.Gia,
                    AnhPhim = x.AnhPhim,
                    NgayBatDau = x.NgayBatDau,
                    NgayKetThuc = x.NgayKetThuc,
                    QuocGia = x.QuocGia,
                    HangPhim = x.HangPhim,
                    PhienBan = x.PhienBan,
                    TheLoai = x.TheLoai,
                    TrangThai = x.TrangThai,
                    MaRap = x.MaRap,

                }).ToListAsync();
        }
    }
}
