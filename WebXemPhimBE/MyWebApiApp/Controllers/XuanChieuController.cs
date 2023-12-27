using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XuanChieuController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public XuanChieuController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<XuatChieu>> GetAllXuatChieu()
        {
            return await _dbContext.XuatChieus.ToListAsync();
        }

        [HttpPost("byPhim")]
        public async Task<IEnumerable<XuatChieu>> GetXuatChieuByPhim(XuatChieuRequestModel model)
        {
            return await _dbContext.XuatChieus
                .Where(x => x.NgayChieu.Day == model.Ngay && x.NgayChieu.Month == model.Thang && x.NgayChieu.Year == model.Nam && x.MaPhim == model.MaPhim)
                .ToListAsync();
        }

        [HttpPost]
        public async Task AddXuatChieu(XuatChieuModel input)
        {
            var comment = new XuatChieu
            {
                MaXuatChieu = input.MaXuatChieu,
                NgayChieu = input.NgayChieu,
                Gio = input.Gio,
                Phut = input.Phut,
                MaPhim = input.MaPhim
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
       
        [HttpDelete]
        public async Task DeleteXuatChieu(int id)
        {
            var commentId = _dbContext.XuatChieus.Where(x => x.MaXuatChieu == id).FirstOrDefault();
            _dbContext.XuatChieus.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
