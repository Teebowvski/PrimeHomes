using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeHomes.Data.Migrations
{
    public partial class Initial234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainContent3",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainContent3",
                table: "Blogs");
        }
    }
}
