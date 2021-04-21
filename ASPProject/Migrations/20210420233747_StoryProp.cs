using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPProject.Migrations
{
    public partial class StoryProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Story",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Story",
                table: "Anime");
        }
    }
}
