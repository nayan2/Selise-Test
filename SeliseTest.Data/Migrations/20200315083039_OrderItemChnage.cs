using Microsoft.EntityFrameworkCore.Migrations;

namespace SeliseTest.Data.Migrations
{
    public partial class OrderItemChnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderItems");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "OrderItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CustomerId",
                table: "OrderItems",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Customers_CustomerId",
                table: "OrderItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Customers_CustomerId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CustomerId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
