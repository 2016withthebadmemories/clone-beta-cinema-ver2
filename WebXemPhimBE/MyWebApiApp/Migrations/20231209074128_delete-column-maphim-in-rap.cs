using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class deletecolumnmaphiminrap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raps_Phims_MaPhim",
                table: "Raps");

            migrationBuilder.DropIndex(
                name: "IX_Raps_MaPhim",
                table: "Raps");

            migrationBuilder.DropColumn(
                name: "MaPhim",
                table: "Raps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaPhim",
                table: "Raps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Raps_MaPhim",
                table: "Raps",
                column: "MaPhim");

            migrationBuilder.AddForeignKey(
                name: "FK_Raps_Phims_MaPhim",
                table: "Raps",
                column: "MaPhim",
                principalTable: "Phims",
                principalColumn: "MaPhim",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
