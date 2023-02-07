using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeHomes.Data.Migrations
{
    public partial class Initial2345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorImageUrl",
                table: "Blogs");
        }
    }
}
