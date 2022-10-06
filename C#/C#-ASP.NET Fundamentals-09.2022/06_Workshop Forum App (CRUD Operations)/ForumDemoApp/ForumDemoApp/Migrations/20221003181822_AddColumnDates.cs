using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumDemoApp.Migrations
{
    public partial class AddColumnDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Post create on");

            migrationBuilder.AddColumn<string>(
                name: "DeletedDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Post deleted on");

            migrationBuilder.AddColumn<string>(
                name: "EditedDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Post last edited on");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Posts");
        }
    }
}
