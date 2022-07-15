using Microsoft.EntityFrameworkCore.Migrations;

namespace Alat.Data.Migrations
{
    public partial class smsotpphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "otpVerifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "otpVerifications");
        }
    }
}
