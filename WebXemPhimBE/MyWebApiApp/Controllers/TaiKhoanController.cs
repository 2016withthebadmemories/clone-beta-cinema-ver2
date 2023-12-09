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
    public class TaiKhoanController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public TaiKhoanController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TaiKhoan>> GetAll()
        {
            return await _dbContext.TaiKhoans.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<TaiKhoan> GetById(int id)
        {
            return await _dbContext.TaiKhoans.FindAsync(id);
        }

        [HttpPost]
        public async Task Add(TaiKhoanModel input)
        {
            var comment = new TaiKhoan
            {
                MaTaiKhoan = input.MaTaiKhoan,
                MatKhau = input.MatKhau,
                AnhDaiDien = input.AnhDaiDien,
                Email = input.Email,
                SoDienThoai = input.SoDienThoai,
                NgaySinh = input.NgaySinh,
                LoaiTaiKhoan= input.LoaiTaiKhoan
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task Update(TaiKhoan comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var commentId = _dbContext.TaiKhoans.Where(x => x.MaTaiKhoan == id).FirstOrDefault();
            _dbContext.TaiKhoans.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}

