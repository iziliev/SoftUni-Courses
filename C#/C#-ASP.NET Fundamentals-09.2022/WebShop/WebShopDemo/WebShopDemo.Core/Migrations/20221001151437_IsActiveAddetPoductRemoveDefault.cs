using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopDemo.Core.Migrations
{
    public partial class IsActiveAddetPoductRemoveDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_avaylable",
                table: "products",
                type: "boolean",
                nullable: false,
                comment: "Product in stosk",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true,
                oldComment: "Product in stosk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_avaylable",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "Product in stosk",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Product in stosk");
        }
    }
}
