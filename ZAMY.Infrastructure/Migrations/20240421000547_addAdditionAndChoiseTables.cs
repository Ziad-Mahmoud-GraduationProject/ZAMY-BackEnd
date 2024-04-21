using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAMY.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAdditionAndChoiseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addition_Meals_MealId",
                table: "Addition");

            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Meals_MealId",
                table: "Choice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choice",
                table: "Choice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addition",
                table: "Addition");

            migrationBuilder.RenameTable(
                name: "Choice",
                newName: "Choices");

            migrationBuilder.RenameTable(
                name: "Addition",
                newName: "Additions");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_MealId",
                table: "Choices",
                newName: "IX_Choices_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Addition_MealId",
                table: "Additions",
                newName: "IX_Additions_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choices",
                table: "Choices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Additions",
                table: "Additions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Additions_Meals_MealId",
                table: "Additions",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Meals_MealId",
                table: "Choices",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Additions_Meals_MealId",
                table: "Additions");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Meals_MealId",
                table: "Choices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choices",
                table: "Choices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Additions",
                table: "Additions");

            migrationBuilder.RenameTable(
                name: "Choices",
                newName: "Choice");

            migrationBuilder.RenameTable(
                name: "Additions",
                newName: "Addition");

            migrationBuilder.RenameIndex(
                name: "IX_Choices_MealId",
                table: "Choice",
                newName: "IX_Choice_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Additions_MealId",
                table: "Addition",
                newName: "IX_Addition_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choice",
                table: "Choice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addition",
                table: "Addition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addition_Meals_MealId",
                table: "Addition",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Meals_MealId",
                table: "Choice",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
