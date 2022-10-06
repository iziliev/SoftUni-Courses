using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopDemo.Core.Migrations
{
    public partial class ChangeNameDeleteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_delete_date",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "deleted_date",
                table: "products",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_date",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "is_delete_date",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
