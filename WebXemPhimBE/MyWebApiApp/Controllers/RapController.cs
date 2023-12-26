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
        public async Task<IEnumerable<Rap>> GetAllRap()
        {
            return await _dbContext.Raps.ToListAsync();
        }

        [HttpPost]
        public async Task AddRap(RapModel input)
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
        public async Task UpdateRap(Rap comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteRap(int id)
        {
            var commentId = _dbContext.Raps.Where(x => x.MaRap == id).FirstOrDefault();
            _dbContext.Raps.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }
    }
}
