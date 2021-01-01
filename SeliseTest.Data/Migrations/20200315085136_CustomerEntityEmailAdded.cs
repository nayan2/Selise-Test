using Microsoft.EntityFrameworkCore.Migrations;

namespace SeliseTest.Data.Migrations
{
    public partial class CustomerEntityEmailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_Email",
                table: "Customers",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");
        }
    }
}
