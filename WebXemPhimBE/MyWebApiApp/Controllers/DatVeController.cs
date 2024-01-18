using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Migrations;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatVeController : ControllerBase
    {

        private readonly MyDbContext _dbContext;

        public DatVeController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public async Task DatVePro(DatVePro input)
        {
            var ghes = _dbContext.Ghes.Where(x => input.MaGhes.Contains(x.MaGhe)).ToList();

            DateTime date = DateTime.Now;
            var datVe1 = new DatVe
            {
                SoLuong = input.SoLuong,
                TongGia = input.TongGia,
                MaTaiKhoan = input.MaTaiKhoan,
                NgayDatVe = date
            };

            await _dbContext.AddAsync(datVe1);
            await _dbContext.SaveChangesAsync();

            for (int i = 0; i < input.MaGhes.Count; i++)
            {
                var ve1 = new Ve
                {
                    MaDatVe = datVe1.MaDatVe,
                    MaXuatChieu = input.MaXuatChieu,
                    MaGhe = input.MaGhes[i],
                };
                await _dbContext.AddAsync(ve1);
            }

            await _dbContext.SaveChangesAsync();
        }

        [HttpPost("DatVePro1")]
        public async Task<IActionResult> DatVePro1([FromQuery] DatVePro input)
        {
            var ghes = _dbContext.Ghes.Where(x => input.MaGhes.Contains(x.MaGhe)).ToList();

            DateTime date = DateTime.Now;
            var datVe1 = new DatVe
            {
                SoLuong = input.SoLuong,
                TongGia = input.TongGia,
                MaTaiKhoan = input.MaTaiKhoan,
                NgayDatVe = date
            };

            await _dbContext.AddAsync(datVe1);
            await _dbContext.SaveChangesAsync();

            for (int i = 0; i < input.MaGhes.Count; i++)
            {
                var ve1 = new Ve
                {
                    MaDatVe = datVe1.MaDatVe,
                    MaXuatChieu = input.MaXuatChieu,
                    MaGhe = input.MaGhes[i],
                };
                await _dbContext.AddAsync(ve1);
            }

            await _dbContext.SaveChangesAsync();

            return Ok("Đã đặt vé thành công");
        }

        [HttpGet("GetAllDatVeInfo")]
        public IActionResult GetAllDatVeInfo()
        {
            var allDatVeInfo = _dbContext.DatVes
                .Select(dv => new DatVeInfo
                {
                    SoLuong = dv.SoLuong,
                    TongGia = dv.TongGia,
                    NgayDatVe = dv.NgayDatVe,
                    MaDatVe = dv.MaDatVe,
                    Email = _dbContext.TaiKhoans
                        .Where(tk => tk.MaTaiKhoan == dv.MaTaiKhoan)
                        .Select(tk => tk.Email)
                        .FirstOrDefault(),
                    XuatChieu = _dbContext.Ves
                        .Where(ve => ve.MaDatVe == dv.MaDatVe)
                        .Join(_dbContext.XuatChieus,
                            ve => ve.MaXuatChieu,
                            xc => xc.MaXuatChieu,
                            (ve, xc) => new XuatChieuInfo
                            {
                                MaXuatChieu = xc.MaXuatChieu,
                                Gio = xc.Gio,
                                Phut = xc.Phut,
                                TenPhim = _dbContext.Phims
                                    .Where(phim => phim.MaPhim == xc.MaPhim)
                                    .Select(phim => phim.TenPhim)
                                    .FirstOrDefault(),
                                TenRap = _dbContext.Raps
                                    .Where(rap => rap.MaRap == _dbContext.Phims
                                        .Where(phim => phim.MaPhim == xc.MaPhim)
                                        .Select(phim => phim.MaRap)
                                        .FirstOrDefault())
                                    .Select(rap => rap.TenRap)
                                    .FirstOrDefault(),
                                TenPhong = _dbContext.Phongs
                                    .Where(phong => phong.MaPhong == xc.MaPhong)
                                    .Select(phong => phong.TenPhong)
                                    .FirstOrDefault()
                            })
                        .FirstOrDefault(),
                    Ghes = _dbContext.Ves
                        .Where(ve => ve.MaDatVe == dv.MaDatVe)
                        .SelectMany(v => _dbContext.Ghes
                            .Where(g => g.MaGhe == v.MaGhe)
                            .Select(g => new GheVe
                            {
                                MaGhe = g.MaGhe,
                                TenGhe = g.TenGhe
                            }))
                        .ToList()
                })
                .ToList();

            return Ok(allDatVeInfo);
        }


        [HttpGet("GetDatVeHistoryByMaTaiKhoan")]
        public IActionResult GetAllDatVe2Info(int maTaiKhoan)
        {
            var allDatVeInfo = _dbContext.DatVes
                .Where(x => x.MaTaiKhoan == maTaiKhoan)
                .OrderByDescending(dv => dv.NgayDatVe)
                .Select(dv => new DatVeInfo
                {
                    SoLuong = dv.SoLuong,
                    TongGia = dv.TongGia,
                    NgayDatVe = dv.NgayDatVe,
                    MaDatVe = dv.MaDatVe,
                    Email = _dbContext.TaiKhoans
                        .Where(tk => tk.MaTaiKhoan == maTaiKhoan)
                        .Select(tk => tk.Email)
                        .FirstOrDefault(),
                    XuatChieu = _dbContext.Ves
                        .Where(ve => ve.MaDatVe == dv.MaDatVe)
                        .Join(_dbContext.XuatChieus,
                            ve => ve.MaXuatChieu,
                            xc => xc.MaXuatChieu,
                            (ve, xc) => new XuatChieuInfo
                            {
                                MaXuatChieu = xc.MaXuatChieu,
                                Gio = xc.Gio,
                                Phut = xc.Phut,
                                TenPhim = _dbContext.Phims
                                    .Where(phim => phim.MaPhim == xc.MaPhim)
                                    .Select(phim => phim.TenPhim)
                                    .FirstOrDefault(),
                                TenRap = _dbContext.Raps
                                    .Where(rap => rap.MaRap == _dbContext.Phims
                                        .Where(phim => phim.MaPhim == xc.MaPhim)
                                        .Select(phim => phim.MaRap)
                                        .FirstOrDefault())
                                    .Select(rap => rap.TenRap)
                                    .FirstOrDefault(),
                                TenPhong = _dbContext.Phongs
                                    .Where(phong => phong.MaPhong == xc.MaPhong)
                                    .Select(phong => phong.TenPhong)
                                    .FirstOrDefault()
                            })
                        .FirstOrDefault(),
                    Ghes = _dbContext.Ves
                        .Where(ve => ve.MaDatVe == dv.MaDatVe)
                        .SelectMany(v => _dbContext.Ghes
                            .Where(g => g.MaGhe == v.MaGhe)
                            .Select(g => new GheVe
                            {
                                MaGhe = g.MaGhe,
                                TenGhe = g.TenGhe
                            }))
                        .ToList()
                })
                .ToList();

            return Ok(allDatVeInfo);
        }


        [HttpGet("GetDatVeInfoById")]
        public IActionResult GetDatVeInfoById(int maDatVe)
        {
            var datVeInfo = _dbContext.Ves
                .Where(ve => ve.MaDatVe == maDatVe)
                .Select(ve => new DatVeInfo
                {
                    SoLuong = ve.DatVe.SoLuong,
                    TongGia = ve.DatVe.TongGia,
                    NgayDatVe = ve.DatVe.NgayDatVe,
                    MaDatVe = ve.DatVe.MaDatVe,
                    Email = _dbContext.TaiKhoans
                        .Where(tk => tk.MaTaiKhoan == ve.DatVe.MaTaiKhoan)
                        .Select(tk => tk.Email)
                        .FirstOrDefault(),
                    XuatChieu = new XuatChieuInfo
                    {
                        MaXuatChieu = ve.MaXuatChieu,
                        Gio = _dbContext.XuatChieus
                            .Where(xc => xc.MaXuatChieu == ve.MaXuatChieu)
                            .Select(xc => xc.Gio)
                            .FirstOrDefault(),
                        Phut = _dbContext.XuatChieus
                            .Where(xc => xc.MaXuatChieu == ve.MaXuatChieu)
                            .Select(xc => xc.Phut)
                            .FirstOrDefault()
                    },
                    Ghes = _dbContext.Ves
                                    .Where(v => v.MaDatVe == maDatVe)
                                    .SelectMany(v => _dbContext.Ghes
                                    .Where(g => g.MaGhe == v.MaGhe)
                                      .Select(g => new GheVe
                                      {
                                          MaGhe = g.MaGhe,
                                          TenGhe = g.TenGhe
                                      }))
                                    .ToList()
                })
                .FirstOrDefault();

            if (datVeInfo == null)
            {
                return NotFound("Không tìm thấy thông tin đặt vé cho mã vé này.");
            }

            return Ok(datVeInfo);
        }

        [HttpDelete]
        public async Task DeleteDatVeByMaDatVe(int maDatVe)
        {
            var vesToDelete = _dbContext.Ves
                .Where(ve => ve.MaDatVe == maDatVe)
                .ToList();

            if (vesToDelete.Count == 0)
            {
            }

            foreach (var ve in vesToDelete)
            {
                _dbContext.Ves.Remove(ve);
            }

            var datVeToDelete = _dbContext.DatVes.FirstOrDefault(dv => dv.MaDatVe == maDatVe);
            if (datVeToDelete != null)
            {
                _dbContext.DatVes.Remove(datVeToDelete);
            }

            _dbContext.SaveChanges();

        }


        [HttpGet("GetDatVeInfoByMaTaiKhoanVaMaXuatChieu")]
        public IActionResult GetDatVeInfoById1(int maXuatChieu, int maTaiKhoan)
        {
            var datVeInfo = _dbContext.Ves
                .Where(ve => ve.MaXuatChieu == maXuatChieu && ve.DatVe.MaTaiKhoan == maTaiKhoan)
                .Select(ve => new DatVeInfo
                {
                    SoLuong = ve.DatVe.SoLuong,
                    TongGia = ve.DatVe.TongGia,
                    NgayDatVe = ve.DatVe.NgayDatVe,
                    MaDatVe = ve.DatVe.MaDatVe,
                    Email = _dbContext.TaiKhoans
                        .Where(tk => tk.MaTaiKhoan == maTaiKhoan)
                        .Select(tk => tk.Email)
                        .FirstOrDefault(),
                    XuatChieu = new XuatChieuInfo
                    {
                        MaXuatChieu = ve.MaXuatChieu,
                        Gio = _dbContext.XuatChieus
                            .Where(xc => xc.MaXuatChieu == ve.MaXuatChieu)
                            .Select(xc => xc.Gio)
                            .FirstOrDefault(),
                        Phut = _dbContext.XuatChieus
                            .Where(xc => xc.MaXuatChieu == ve.MaXuatChieu)
                            .Select(xc => xc.Phut)
                            .FirstOrDefault()
                    },
                    Ghes = _dbContext.Ves
                        .Where(v => v.MaXuatChieu == maXuatChieu && v.DatVe.MaTaiKhoan == maTaiKhoan)
                        .SelectMany(v => _dbContext.Ghes
                            .Where(g => g.MaGhe == v.MaGhe)
                            .Select(g => new GheVe
                            {
                                MaGhe = g.MaGhe,
                                TenGhe = g.TenGhe
                            }))
                        .ToList()
                })
                .FirstOrDefault();

            if (datVeInfo == null)
            {
                return NotFound("Không tìm thấy thông tin đặt vé cho mã xuất chiếu và mã tài khoản này.");
            }

            return Ok(datVeInfo);
        }

        [HttpGet("lay-danh-sach-phim")]
        public IActionResult LayDanhSachPhimTheoMaRap(DateTime ngayChieu)
        {
            var result = (from ve in _dbContext.Ves
                          join xc in _dbContext.XuatChieus on ve.MaXuatChieu equals xc.MaXuatChieu
                          join phim in _dbContext.Phims on xc.MaPhim equals phim.MaPhim
                          join rap in _dbContext.Raps on phim.MaRap equals rap.MaRap
                          where xc.NgayChieu == ngayChieu
                          select new
                          {
                              Phim = phim,
                              TongTien = ve.DatVe.TongGia,
                              Rap = rap
                          }).Distinct().ToList();

            return Ok(result);
        }

        [HttpGet("lay-danh-sach-phim1")]
        public IActionResult LayDanhSachPhimTheoMaRap1(DateTime ngayChieu)
        {
            var result = (from ve in _dbContext.Ves
                          join xc in _dbContext.XuatChieus on ve.MaXuatChieu equals xc.MaXuatChieu
                          join phim in _dbContext.Phims on xc.MaPhim equals phim.MaPhim
                          join rap in _dbContext.Raps on phim.MaRap equals rap.MaRap
                          where xc.NgayChieu == ngayChieu
                          select new
                          {
                              Phim = phim,
                              TongTien = ve.DatVe.TongGia,
                              Rap = rap
                          }).Distinct().ToList();

            var sortedResult = result.OrderBy(x => x.Rap.TenRap).ThenBy(x => x.TongTien).ToList();

            return Ok(sortedResult);
        }


    }
}
