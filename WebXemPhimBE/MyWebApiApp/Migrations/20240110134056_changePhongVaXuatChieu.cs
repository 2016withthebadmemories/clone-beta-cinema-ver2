using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class changePhongVaXuatChieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phongs_XuatChieus_MaXuatChieu",
                table: "Phongs");

            migrationBuilder.DropIndex(
                name: "IX_Phongs_MaXuatChieu",
                table: "Phongs");

            migrationBuilder.DropColumn(
                name: "MaXuatChieu",
                table: "Phongs");

            migrationBuilder.AddColumn<int>(
                name: "MaPhong",
                table: "XuatChieus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_XuatChieus_MaPhong",
                table: "XuatChieus",
                column: "MaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_XuatChieus_Phongs_MaPhong",
                table: "XuatChieus",
                column: "MaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XuatChieus_Phongs_MaPhong",
                table: "XuatChieus");

            migrationBuilder.DropIndex(
                name: "IX_XuatChieus_MaPhong",
                table: "XuatChieus");

            migrationBuilder.DropColumn(
                name: "MaPhong",
                table: "XuatChieus");

            migrationBuilder.AddColumn<int>(
                name: "MaXuatChieu",
                table: "Phongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_MaXuatChieu",
                table: "Phongs",
                column: "MaXuatChieu");

            migrationBuilder.AddForeignKey(
                name: "FK_Phongs_XuatChieus_MaXuatChieu",
                table: "Phongs",
                column: "MaXuatChieu",
                principalTable: "XuatChieus",
                principalColumn: "MaXuatChieu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
