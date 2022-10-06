using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumDemoApp.Migrations
{
    public partial class Initialise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Post id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Post title"),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Post content"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Post is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                },
                comment: "Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
