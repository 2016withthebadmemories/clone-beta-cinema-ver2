using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class suaDatVe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ves_XuatChieus_MaXuaChieu",
                table: "Ves");

            migrationBuilder.RenameColumn(
                name: "MaXuaChieu",
                table: "Ves",
                newName: "MaXuatChieu");

            migrationBuilder.RenameIndex(
                name: "IX_Ves_MaXuaChieu",
                table: "Ves",
                newName: "IX_Ves_MaXuatChieu");

            migrationBuilder.AddForeignKey(
                name: "FK_Ves_XuatChieus_MaXuatChieu",
                table: "Ves",
                column: "MaXuatChieu",
                principalTable: "XuatChieus",
                principalColumn: "MaXuatChieu",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ves_XuatChieus_MaXuatChieu",
                table: "Ves");

            migrationBuilder.RenameColumn(
                name: "MaXuatChieu",
                table: "Ves",
                newName: "MaXuaChieu");

            migrationBuilder.RenameIndex(
                name: "IX_Ves_MaXuatChieu",
                table: "Ves",
                newName: "IX_Ves_MaXuaChieu");

            migrationBuilder.AddForeignKey(
                name: "FK_Ves_XuatChieus_MaXuaChieu",
                table: "Ves",
                column: "MaXuaChieu",
                principalTable: "XuatChieus",
                principalColumn: "MaXuatChieu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
