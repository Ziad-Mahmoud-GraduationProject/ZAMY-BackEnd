using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAMY.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitchenPhoto_Kitchens_KitchenId",
                table: "KitchenPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KitchenPhoto",
                table: "KitchenPhoto");

            migrationBuilder.RenameTable(
                name: "KitchenPhoto",
                newName: "KitchenPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_KitchenPhoto_KitchenId",
                table: "KitchenPhotos",
                newName: "IX_KitchenPhotos_KitchenId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MainCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KitchenPhotos",
                table: "KitchenPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KitchenPhotos_Kitchens_KitchenId",
                table: "KitchenPhotos",
                column: "KitchenId",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitchenPhotos_Kitchens_KitchenId",
                table: "KitchenPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KitchenPhotos",
                table: "KitchenPhotos");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MainCategories");

            migrationBuilder.RenameTable(
                name: "KitchenPhotos",
                newName: "KitchenPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_KitchenPhotos_KitchenId",
                table: "KitchenPhoto",
                newName: "IX_KitchenPhoto_KitchenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KitchenPhoto",
                table: "KitchenPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KitchenPhoto_Kitchens_KitchenId",
                table: "KitchenPhoto",
                column: "KitchenId",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
