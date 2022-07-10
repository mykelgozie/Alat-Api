using Microsoft.EntityFrameworkCore.Migrations;

namespace Alat.Data.Migrations
{
    public partial class adlgawithuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LgaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LgaId",
                table: "AspNetUsers",
                column: "LgaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lgas_LgaId",
                table: "AspNetUsers",
                column: "LgaId",
                principalTable: "Lgas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lgas_LgaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LgaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LgaId",
                table: "AspNetUsers");
        }
    }
}
