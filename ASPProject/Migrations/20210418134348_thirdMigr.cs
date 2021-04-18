using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPProject.Migrations
{
    public partial class thirdMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "WatchingStatus",
                table: "UsersAnime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Anime",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPremium",
                table: "Anime",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    AnimeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCategories", x => new { x.CategoryID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimeCategories_Anime_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Anime",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCategories_AnimeID",
                table: "AnimeCategories",
                column: "AnimeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "WatchingStatus",
                table: "UsersAnime");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "isPremium",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
