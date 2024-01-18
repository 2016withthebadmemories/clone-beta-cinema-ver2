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
using System.IO;

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
                                                    .Where(x => x.TrangThai == true)
                                                    .OrderByDescending(p => p.NgayTao)
                                                    .ToListAsync();

            return distinctPhimNames;
        }

        [HttpPut("UpdateGia")]
        public async Task UpdateMoviePrices(List<int> listRap, float giaMoi)
        {
            // Get all movies for the specified cinema codes (listRap)
            var moviesToUpdate = await _dbContext.Phims
                .Where(x => listRap.Contains(x.MaRap))
                .ToListAsync();

            // Update the prices of the movies
            foreach (var movie in moviesToUpdate)
            {
                movie.Gia = giaMoi;
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }



        [HttpGet("allPhim")]
        public async Task<IEnumerable<PhimModel>> GetAllPhim()
        {
            var allPhims = await _dbContext.Phims.Where(x => x.TrangThai == true).OrderByDescending(p => p.NgayTao).ToListAsync();

            var listRapIds = allPhims.Select(x => x.MaRap).ToList();

            var rapNames = await _dbContext.Raps
                                        .Where(r => listRapIds.Contains(r.MaRap))
                                        .Select(r => new { r.MaRap, r.TenRap })
                                        .ToListAsync();

            var result = allPhims.Select(phim => new PhimModel
            {
                MaPhim = phim.MaPhim,
                TenPhim = phim.TenPhim,
                MoTa = phim.MoTa,
                DienVien = phim.DienVien,
                Daodien = phim.Daodien,
                Gia = phim.Gia,
                AnhPhim = phim.AnhPhim,
                //NgayBatDau = phim.NgayBatDau,
                //NgayKetThuc = phim.NgayKetThuc,
                NgayTao = phim.NgayTao,
                LinkTrailer = phim.LinkTrailer,
                QuocGia = phim.QuocGia,
                HangPhim = phim.HangPhim,
                PhienBan = phim.PhienBan,
                TheLoai = phim.TheLoai,
                TrangThai = phim.TrangThai,
                ThoiLuong = phim.ThoiLuong,
                TenRap = rapNames.FirstOrDefault(r => r.MaRap == phim.MaRap)?.TenRap
            });

            return result;
        }

        [HttpGet("allPhimAdmin")]
        public async Task<IEnumerable<PhimModel>> GetAllPhima(
            int? maRap = null,
            DateTime? ngayTao = null,
            bool? trangThai = null,
            string tenPhim = null,
            string daodien = null,
            string hangPhim = null,
            string quocGia = null)
        {
            IQueryable<Phim> query = _dbContext.Phims;

            // Áp dụng các điều kiện where nếu có tham số được truyền vào
            if (maRap.HasValue)
            {
                query = query.Where(p => p.MaRap == maRap);
            }
            if (ngayTao.HasValue)
            {
                query = query.Where(p => p.NgayTao == ngayTao);
            }
            if (trangThai.HasValue)
            {
                query = query.Where(p => p.TrangThai == trangThai);
            }
            if (!string.IsNullOrEmpty(tenPhim))
            {
                query = query.Where(p => p.TenPhim.Contains(tenPhim));
            }
            if (!string.IsNullOrEmpty(daodien))
            {
                query = query.Where(p => p.Daodien.Contains(daodien));
            }
            if (!string.IsNullOrEmpty(hangPhim))
            {
                query = query.Where(p => p.HangPhim.Contains(hangPhim));
            }
            if (!string.IsNullOrEmpty(quocGia))
            {
                query = query.Where(p => p.QuocGia.Contains(quocGia));
            }

            var allPhims = await query.OrderByDescending(p => p.NgayTao).ToListAsync();



            var listRapIds = allPhims.Select(x => x.MaRap).ToList();

            var rapNames = await _dbContext.Raps
                                        .Where(r => listRapIds.Contains(r.MaRap))
                                        .Select(r => new { r.MaRap, r.TenRap })
                                        .ToListAsync();

            var result = allPhims.Select(phim => new PhimModel
            {
                MaPhim = phim.MaPhim,
                TenPhim = phim.TenPhim,
                MoTa = phim.MoTa,
                DienVien = phim.DienVien,
                Daodien = phim.Daodien,
                Gia = phim.Gia,
                AnhPhim = phim.AnhPhim,
                //NgayBatDau = phim.NgayBatDau,
                //NgayKetThuc = phim.NgayKetThuc,
                NgayTao = phim.NgayTao,
                LinkTrailer = phim.LinkTrailer,
                QuocGia = phim.QuocGia,
                HangPhim = phim.HangPhim,
                PhienBan = phim.PhienBan,
                TheLoai = phim.TheLoai,
                TrangThai = phim.TrangThai,
                ThoiLuong = phim.ThoiLuong,
                MaRap = phim.MaRap,
                TenRap = rapNames.FirstOrDefault(r => r.MaRap == phim.MaRap)?.TenRap
            });

            return result;
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
                                                      .Where(x => x.TrangThai == true)
                                                      .OrderByDescending(p => p.NgayTao)
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
        public async Task<ActionResult<PhimModel>> GetPhimById(int id)
        {
            var phim = await _dbContext.Phims
                .Include(p => p.Rap)
                .FirstOrDefaultAsync(p => p.MaPhim == id);

            if (phim == null)
            {
                return NotFound();
            }

            var phimModel = new PhimModel
            {
                MaPhim = phim.MaPhim,
                TenPhim = phim.TenPhim,
                MoTa = phim.MoTa,
                DienVien = phim.DienVien,
                Daodien = phim.Daodien,
                Gia = phim.Gia,
                AnhPhim = phim.AnhPhim,
                NgayTao = phim.NgayTao,
                LinkTrailer = phim.LinkTrailer,
                QuocGia = phim.QuocGia,
                HangPhim = phim.HangPhim,
                PhienBan = phim.PhienBan,
                TheLoai = phim.TheLoai,
                TrangThai = phim.TrangThai,
                ThoiLuong = phim.ThoiLuong,
                TenRap = phim.Rap?.TenRap
            };

            return phimModel;
        }


        [HttpPost]
        public async Task<Phim> AddPhimm([FromForm] PhimModel input)
        {
                var path = Path.Combine("wwwroot/images", input.AnhPhimFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await input.AnhPhimFile.CopyToAsync(stream);
                }
            DateTime date = DateTime.Now;
            var phim = new Phim
                {
                    MaPhim = input.MaPhim,
                    TenPhim = input.TenPhim,
                    MoTa = input.MoTa,
                    DienVien = input.DienVien,
                    Daodien = input.Daodien,
                    Gia = input.Gia,
                    //NgayBatDau = input.NgayBatDau,
                    //NgayKetThuc = input.NgayKetThuc,
                    NgayTao = date,
                    LinkTrailer = input.LinkTrailer,
                    QuocGia = input.QuocGia,
                    HangPhim = input.HangPhim,
                    PhienBan = input.PhienBan,
                    TheLoai = input.TheLoai,
                    TrangThai = input.TrangThai,
                    MaRap = input.MaRap,
                    ThoiLuong = input.ThoiLuong,
                    AnhPhim = $"{this.Request.Scheme}://{this.Request.Host}/images/{input.AnhPhimFile.FileName}",
                };

                await _dbContext.AddAsync(phim);
                await _dbContext.SaveChangesAsync();

            return phim;
        }
        [HttpPost("xuatChieu")]
        public async Task UpdateXuatChieu(RequestXuatChieu input)
        {
            foreach (var xuatChieu in input.XuatChieus)
            {
                var xc = new XuatChieu
                {
                    NgayChieu = DateTime.Parse(xuatChieu.NgayChieu),
                    MaPhong = input.MaPhong,
                    Gio = int.Parse(xuatChieu.Gio),
                    Phut = int.Parse(xuatChieu.Phut),
                    MaPhim = input.MaPhim
                };

                await _dbContext.AddAsync(xc);
            }
            await _dbContext.SaveChangesAsync();
        }

        [HttpPut("updateXuatChieu")]
        public async Task UpdateXuatChieu(UpdateXuatChieuRequest input)
        {
            var xuatChieu = await _dbContext.XuatChieus.FindAsync(input.MaXuatChieu);


            xuatChieu.Gio = input.Gio;
            xuatChieu.Phut = input.Phut;

            await _dbContext.SaveChangesAsync();

        }



        [HttpPut]
        public async Task UpdatePhim([FromForm] PhimModel input)
        {
            var isHaveRap = (input.MaRap != null && input.MaRap != 0);
            var phimToUpdate = await _dbContext.Phims.FindAsync(input.MaPhim);
            DateTime date = DateTime.Now;
            if (input.AnhPhimFile != null)
            {
                var path = Path.Combine("wwwroot/images", input.AnhPhimFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await input.AnhPhimFile.CopyToAsync(stream);
                }
                phimToUpdate.AnhPhim = $"{this.Request.Scheme}://{this.Request.Host}/images/{input.AnhPhimFile.FileName}";
            }
            phimToUpdate.TenPhim = input.TenPhim;
            phimToUpdate.MoTa = input.MoTa;
            phimToUpdate.DienVien = input.DienVien;
            phimToUpdate.Daodien = input.Daodien;
            phimToUpdate.Gia = input.Gia;
            //phimToUpdate.NgayBatDau = input.NgayBatDau;
            //phimToUpdate.NgayKetThuc = input.NgayKetThuc;
            phimToUpdate.NgayTao = date;
            phimToUpdate.LinkTrailer = input.LinkTrailer;
            phimToUpdate.QuocGia = input.QuocGia;
            phimToUpdate.HangPhim = input.HangPhim;
            phimToUpdate.PhienBan = input.PhienBan;
            phimToUpdate.TheLoai = input.TheLoai;
            phimToUpdate.TrangThai = input.TrangThai;
            phimToUpdate.MaRap = isHaveRap ? input.MaRap : phimToUpdate.MaRap;
            phimToUpdate.ThoiLuong = input.ThoiLuong;

            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeletePhim(int id)
        {
            var commentsToDelete = await _dbContext.BinhLuans.Where(x => x.MaPhim == id).ToListAsync();

            _dbContext.BinhLuans.RemoveRange(commentsToDelete);

            var phimToDelete = await _dbContext.Phims.FirstOrDefaultAsync(x => x.MaPhim == id);
            _dbContext.Phims.Remove(phimToDelete);
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
                    //NgayBatDau = x.NgayBatDau,
                    //NgayKetThuc = x.NgayKetThuc,
                    NgayTao = x.NgayTao,
                    LinkTrailer = x.LinkTrailer,
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
