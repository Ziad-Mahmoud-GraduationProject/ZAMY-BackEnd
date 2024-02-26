using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAMY.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerAddresses_CustomerAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Offers_OfferId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CustomerMeals");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_OfferId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDiscount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "CustomerAddresses");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Payments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "Orders",
                newName: "KitchenId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OfferId",
                table: "Orders",
                newName: "IX_Orders_KitchenId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Meals",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_OrderId",
                table: "Meals",
                newName: "IX_Meals_OfferId");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "CustomerAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_OfferId",
                table: "Discounts",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_orderId",
                table: "CartItems",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Orders_orderId",
                table: "CartItems",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Offers_OfferId",
                table: "Meals",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Kitchens_KitchenId",
                table: "Orders",
                column: "KitchenId",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Orders_orderId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Offers_OfferId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Kitchens_KitchenId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_OfferId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_orderId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Payments",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "KitchenId",
                table: "Orders",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_KitchenId",
                table: "Orders",
                newName: "IX_Orders_OfferId");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "Meals",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_OfferId",
                table: "Meals",
                newName: "IX_Meals_OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Orders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderDiscount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "CustomerAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "CustomerAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CustomerMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMeals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerAddressId",
                table: "Orders",
                column: "CustomerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_OfferId",
                table: "Discounts",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMeals_CustomerId",
                table: "CustomerMeals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMeals_MealId",
                table: "CustomerMeals",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerAddresses_CustomerAddressId",
                table: "Orders",
                column: "CustomerAddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Offers_OfferId",
                table: "Orders",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
