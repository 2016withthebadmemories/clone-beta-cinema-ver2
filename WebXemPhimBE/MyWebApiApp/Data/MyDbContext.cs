using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Banner> Banners { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<DatVe> DatVes { get; set; }
        public DbSet<Ghe> Ghes { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<Phim> Phims { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<Rap> Raps { get; set; }
        public DbSet<SuKien> SuKiens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Ve> Ves { get; set; }
        public DbSet<XuatChieu> XuatChieus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaiKhoan>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<TaiKhoan>().HasIndex(u => u.SoDienThoai).IsUnique();
        }

        #endregion DbSet
    }
}