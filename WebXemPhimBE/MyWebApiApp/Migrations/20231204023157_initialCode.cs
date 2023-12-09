using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class initialCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    MaBanner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.MaBanner);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiTaiKhoan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.MaTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "DatVes",
                columns: table => new
                {
                    MaDatVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TongGia = table.Column<float>(type: "real", nullable: false),
                    NgayDatVe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatVes", x => x.MaDatVe);
                    table.ForeignKey(
                        name: "FK_DatVes_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    MaPhanQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quyen = table.Column<int>(type: "int", nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.MaPhanQuyen);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ves",
                columns: table => new
                {
                    MaVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDatVe = table.Column<int>(type: "int", nullable: false),
                    MaXuaChieu = table.Column<int>(type: "int", nullable: false),
                    MaGhe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ves", x => x.MaVe);
                    table.ForeignKey(
                        name: "FK_Ves_DatVes_MaDatVe",
                        column: x => x.MaDatVe,
                        principalTable: "DatVes",
                        principalColumn: "MaDatVe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuans",
                columns: table => new
                {
                    MaBinhLuan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    MaPhim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuans", x => x.MaBinhLuan);
                    table.ForeignKey(
                        name: "FK_BinhLuans_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnhKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaPhim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.MaKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "Raps",
                columns: table => new
                {
                    MaRap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenRap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaPhim = table.Column<int>(type: "int", nullable: false),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raps", x => x.MaRap);
                    table.ForeignKey(
                        name: "FK_Raps_TaiKhoans_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phims",
                columns: table => new
                {
                    MaPhim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Daodien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<float>(type: "real", nullable: false),
                    AnhPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuocGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HangPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhienBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    MaRap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phims", x => x.MaPhim);
                    table.ForeignKey(
                        name: "FK_Phims_Raps_MaRap",
                        column: x => x.MaRap,
                        principalTable: "Raps",
                        principalColumn: "MaRap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuKiens",
                columns: table => new
                {
                    MaSuKien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSuKien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnhSuKien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaRap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKiens", x => x.MaSuKien);
                    table.ForeignKey(
                        name: "FK_SuKiens_Raps_MaRap",
                        column: x => x.MaRap,
                        principalTable: "Raps",
                        principalColumn: "MaRap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XuatChieus",
                columns: table => new
                {
                    MaXuatChieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayChieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gio = table.Column<int>(type: "int", nullable: false),
                    Phut = table.Column<int>(type: "int", nullable: false),
                    MaPhim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatChieus", x => x.MaXuatChieu);
                    table.ForeignKey(
                        name: "FK_XuatChieus_Phims_MaPhim",
                        column: x => x.MaPhim,
                        principalTable: "Phims",
                        principalColumn: "MaPhim",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phongs",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongGhe = table.Column<int>(type: "int", nullable: false),
                    MaXuatChieu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongs", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_Phongs_XuatChieus_MaXuatChieu",
                        column: x => x.MaXuatChieu,
                        principalTable: "XuatChieus",
                        principalColumn: "MaXuatChieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ghes",
                columns: table => new
                {
                    MaGhe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGhe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangGhe = table.Column<bool>(type: "bit", nullable: false),
                    Cot = table.Column<int>(type: "int", nullable: false),
                    Hang = table.Column<int>(type: "int", nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghes", x => x.MaGhe);
                    table.ForeignKey(
                        name: "FK_Ghes_Phongs_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongs",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuans_MaPhim",
                table: "BinhLuans",
                column: "MaPhim");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuans_MaTaiKhoan",
                table: "BinhLuans",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_DatVes_MaTaiKhoan",
                table: "DatVes",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Ghes_MaPhong",
                table: "Ghes",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMais_MaPhim",
                table: "KhuyenMais",
                column: "MaPhim");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_MaTaiKhoan",
                table: "PhanQuyens",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Phims_MaRap",
                table: "Phims",
                column: "MaRap");

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_MaXuatChieu",
                table: "Phongs",
                column: "MaXuatChieu");

            migrationBuilder.CreateIndex(
                name: "IX_Raps_MaPhim",
                table: "Raps",
                column: "MaPhim");

            migrationBuilder.CreateIndex(
                name: "IX_Raps_MaTaiKhoan",
                table: "Raps",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_SuKiens_MaRap",
                table: "SuKiens",
                column: "MaRap");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_Email",
                table: "TaiKhoans",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_SoDienThoai",
                table: "TaiKhoans",
                column: "SoDienThoai",
                unique: true,
                filter: "[SoDienThoai] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ves_MaDatVe",
                table: "Ves",
                column: "MaDatVe");

            migrationBuilder.CreateIndex(
                name: "IX_Ves_MaGhe",
                table: "Ves",
                column: "MaGhe");

            migrationBuilder.CreateIndex(
                name: "IX_Ves_MaXuaChieu",
                table: "Ves",
                column: "MaXuaChieu");

            migrationBuilder.CreateIndex(
                name: "IX_XuatChieus_MaPhim",
                table: "XuatChieus",
                column: "MaPhim");

            migrationBuilder.AddForeignKey(
                name: "FK_Ves_Ghes_MaGhe",
                table: "Ves",
                column: "MaGhe",
                principalTable: "Ghes",
                principalColumn: "MaGhe",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ves_XuatChieus_MaXuaChieu",
                table: "Ves",
                column: "MaXuaChieu",
                principalTable: "XuatChieus",
                principalColumn: "MaXuatChieu",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuans_Phims_MaPhim",
                table: "BinhLuans",
                column: "MaPhim",
                principalTable: "Phims",
                principalColumn: "MaPhim",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_KhuyenMais_Phims_MaPhim",
                table: "KhuyenMais",
                column: "MaPhim",
                principalTable: "Phims",
                principalColumn: "MaPhim",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raps_Phims_MaPhim",
                table: "Raps",
                column: "MaPhim",
                principalTable: "Phims",
                principalColumn: "MaPhim",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raps_Phims_MaPhim",
                table: "Raps");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "BinhLuans");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "SuKiens");

            migrationBuilder.DropTable(
                name: "Ves");

            migrationBuilder.DropTable(
                name: "DatVes");

            migrationBuilder.DropTable(
                name: "Ghes");

            migrationBuilder.DropTable(
                name: "Phongs");

            migrationBuilder.DropTable(
                name: "XuatChieus");

            migrationBuilder.DropTable(
                name: "Phims");

            migrationBuilder.DropTable(
                name: "Raps");

            migrationBuilder.DropTable(
                name: "TaiKhoans");
        }
    }
}
