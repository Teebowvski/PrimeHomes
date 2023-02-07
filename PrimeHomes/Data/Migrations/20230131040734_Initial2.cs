using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeHomes.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Blogs",
                newName: "TwitterUrl");

            migrationBuilder.AddColumn<string>(
                name: "AboutAuthor",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogImageUrl2",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkdelUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutAuthor",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogImageUrl",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogImageUrl2",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LinkdelUrl",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "TwitterUrl",
                table: "Blogs",
                newName: "ImageUrl");
        }
    }
}
