using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class changerap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raps_TaiKhoans_MaTaiKhoan",
                table: "Raps");

            migrationBuilder.AlterColumn<int>(
                name: "MaTaiKhoan",
                table: "Raps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Raps_TaiKhoans_MaTaiKhoan",
                table: "Raps",
                column: "MaTaiKhoan",
                principalTable: "TaiKhoans",
                principalColumn: "MaTaiKhoan",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raps_TaiKhoans_MaTaiKhoan",
                table: "Raps");

            migrationBuilder.AlterColumn<int>(
                name: "MaTaiKhoan",
                table: "Raps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Raps_TaiKhoans_MaTaiKhoan",
                table: "Raps",
                column: "MaTaiKhoan",
                principalTable: "TaiKhoans",
                principalColumn: "MaTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
