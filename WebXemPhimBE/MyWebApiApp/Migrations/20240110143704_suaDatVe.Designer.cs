﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApiApp.Data;

namespace MyWebApiApp.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240110143704_suaDatVe")]
    partial class suaDatVe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApiApp.Data.Banner", b =>
                {
                    b.Property<int>("MaBanner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaBanner");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("MyWebApiApp.Data.BinhLuan", b =>
                {
                    b.Property<int>("MaBinhLuan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaPhim")
                        .HasColumnType("int");

                    b.Property<int>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBinhLuan")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaBinhLuan");

                    b.HasIndex("MaPhim");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("BinhLuans");
                });

            modelBuilder.Entity("MyWebApiApp.Data.DatVe", b =>
                {
                    b.Property<int>("MaDatVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDatVe")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<float>("TongGia")
                        .HasColumnType("real");

                    b.HasKey("MaDatVe");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("DatVes");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Ghe", b =>
                {
                    b.Property<int>("MaGhe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cot")
                        .HasColumnType("int");

                    b.Property<int>("Hang")
                        .HasColumnType("int");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenGhe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TinhTrangGhe")
                        .HasColumnType("bit");

                    b.HasKey("MaGhe");

                    b.HasIndex("MaPhong");

                    b.ToTable("Ghes");
                });

            modelBuilder.Entity("MyWebApiApp.Data.KhuyenMai", b =>
                {
                    b.Property<int>("MaKhuyenMai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhKhuyenMai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPhim")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhuyenMai");

                    b.HasIndex("MaPhim");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("MyWebApiApp.Data.PhanQuyen", b =>
                {
                    b.Property<int>("MaPhanQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<int>("Quyen")
                        .HasColumnType("int");

                    b.HasKey("MaPhanQuyen");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("PhanQuyens");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Phim", b =>
                {
                    b.Property<int>("MaPhim")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhPhim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Daodien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DienVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Gia")
                        .HasColumnType("real");

                    b.Property<string>("HangPhim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaRap")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhienBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuocGia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheLoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoiLuong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaPhim");

                    b.HasIndex("MaRap");

                    b.ToTable("Phims");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Phong", b =>
                {
                    b.Property<int>("MaPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongGhe")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaPhong");

                    b.ToTable("Phongs");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Rap", b =>
                {
                    b.Property<int>("MaRap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<string>("TenRap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaRap");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("Raps");
                });

            modelBuilder.Entity("MyWebApiApp.Data.SuKien", b =>
                {
                    b.Property<int>("MaSuKien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhSuKien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaRap")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSuKien")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSuKien");

                    b.HasIndex("MaRap");

                    b.ToTable("SuKiens");
                });

            modelBuilder.Entity("MyWebApiApp.Data.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("LoaiTaiKhoan")
                        .HasColumnType("bit");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaTaiKhoan");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("SoDienThoai")
                        .IsUnique()
                        .HasFilter("[SoDienThoai] IS NOT NULL");

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Ve", b =>
                {
                    b.Property<int>("MaVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaDatVe")
                        .HasColumnType("int");

                    b.Property<int>("MaGhe")
                        .HasColumnType("int");

                    b.Property<int>("MaXuatChieu")
                        .HasColumnType("int");

                    b.HasKey("MaVe");

                    b.HasIndex("MaDatVe");

                    b.HasIndex("MaGhe");

                    b.HasIndex("MaXuatChieu");

                    b.ToTable("Ves");
                });

            modelBuilder.Entity("MyWebApiApp.Data.XuatChieu", b =>
                {
                    b.Property<int>("MaXuatChieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gio")
                        .HasColumnType("int");

                    b.Property<int>("MaPhim")
                        .HasColumnType("int");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayChieu")
                        .HasColumnType("datetime2");

                    b.Property<int>("Phut")
                        .HasColumnType("int");

                    b.HasKey("MaXuatChieu");

                    b.HasIndex("MaPhim");

                    b.HasIndex("MaPhong");

                    b.ToTable("XuatChieus");
                });

            modelBuilder.Entity("MyWebApiApp.Data.BinhLuan", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Phim", "Phim")
                        .WithMany()
                        .HasForeignKey("MaPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApp.Data.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phim");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("MyWebApiApp.Data.DatVe", b =>
                {
                    b.HasOne("MyWebApiApp.Data.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Ghe", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("MyWebApiApp.Data.KhuyenMai", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Phim", "Phim")
                        .WithMany()
                        .HasForeignKey("MaPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phim");
                });

            modelBuilder.Entity("MyWebApiApp.Data.PhanQuyen", b =>
                {
                    b.HasOne("MyWebApiApp.Data.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Phim", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Rap", "Rap")
                        .WithMany()
                        .HasForeignKey("MaRap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rap");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Rap", b =>
                {
                    b.HasOne("MyWebApiApp.Data.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("MaTaiKhoan");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("MyWebApiApp.Data.SuKien", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Rap", "Rap")
                        .WithMany()
                        .HasForeignKey("MaRap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rap");
                });

            modelBuilder.Entity("MyWebApiApp.Data.Ve", b =>
                {
                    b.HasOne("MyWebApiApp.Data.DatVe", "DatVe")
                        .WithMany()
                        .HasForeignKey("MaDatVe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApp.Data.Ghe", "Ghe")
                        .WithMany()
                        .HasForeignKey("MaGhe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApp.Data.XuatChieu", "XuatChieu")
                        .WithMany()
                        .HasForeignKey("MaXuatChieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DatVe");

                    b.Navigation("Ghe");

                    b.Navigation("XuatChieu");
                });

            modelBuilder.Entity("MyWebApiApp.Data.XuatChieu", b =>
                {
                    b.HasOne("MyWebApiApp.Data.Phim", "Phim")
                        .WithMany()
                        .HasForeignKey("MaPhim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApiApp.Data.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phim");

                    b.Navigation("Phong");
                });
#pragma warning restore 612, 618
        }
    }
}
