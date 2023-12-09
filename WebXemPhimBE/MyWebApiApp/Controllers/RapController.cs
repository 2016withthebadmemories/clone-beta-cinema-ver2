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
    public class RapController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public RapController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Rap>> GetAllBinhLuan()
        {
            return await _dbContext.Raps.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Rap> GetBinhLuanById(int id)
        {
            return await _dbContext.Raps.FindAsync(id);
        }

        [HttpPost]
        public async Task AddBinhLuan(RapModel input)
        {
            var comment = new Rap
            {
                MaRap = input.MaRap,
                TenRap = input.TenRap,
                DiaChi = input.DiaChi,
                MaTaiKhoan = input.MaTaiKhoan,
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPut]
        public async Task UpdateBinhLuan(Rap comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteBinhLuan(int id)
        {
            var commentId = _dbContext.Raps.Where(x => x.MaRap == id).FirstOrDefault();
            _dbContext.Raps.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
