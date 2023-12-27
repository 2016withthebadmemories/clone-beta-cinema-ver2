using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly Appsetting _appsetting;

        public TaiKhoanController(MyDbContext contex, IOptionsMonitor<Appsetting>
            optionsMonitor)
        {
            _dbContext = contex;
            _appsetting = optionsMonitor.CurrentValue;
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
                LoaiTaiKhoan = input.LoaiTaiKhoan
            };
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
        //[HttpPut]
        //public async Task Update(TaiKhoan comment)
        //{
        //    _dbContext.Entry(comment).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}

        [HttpDelete]
        public async Task Delete(int id)
        {
            var commentId = _dbContext.TaiKhoans.Where(x => x.MaTaiKhoan == id).FirstOrDefault();
            _dbContext.TaiKhoans.Remove(commentId);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _dbContext.TaiKhoans.SingleOrDefault(p => p.Email ==
            model.Email && model.MatKhau == p.MatKhau);
            if (user == null) // Không đúng người dùng
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Invalid Username/Password",
                });
            }
            // Cấp Token
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user),
                MaTaiKhoan = user.MaTaiKhoan,
                Email = user.Email,
            });
        }

        [HttpPut]
        public IActionResult Edit(string id, ChangePasswordModel input)
        {
            try
            {
                var user = _dbContext.TaiKhoans.SingleOrDefault(hh => hh.MaTaiKhoan == input.MaTaiKhoan);
                if (user == null)
                {
                    return NotFound();
                }

                if (id != user.MaTaiKhoan.ToString())
                {
                    return BadRequest();
                }
                // Update
                user.MatKhau = input.MatKhau;
                _dbContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        private string GenerateToken(TaiKhoan user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appsetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("MaTaiKhoan", user.MaTaiKhoan.ToString()),

                    // Roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes
                ), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}