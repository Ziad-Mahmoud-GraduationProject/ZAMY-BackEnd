using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAMY.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addimageto_main_sub_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "MainCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "MainCategories");
        }
    }
}
