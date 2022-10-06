using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopDemo.Core.Migrations
{
    public partial class IsdeletedCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_date",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "is_delete_date",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modified_date",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_date",
                table: "products");

            migrationBuilder.DropColumn(
                name: "is_delete_date",
                table: "products");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "products");
        }
    }
}
