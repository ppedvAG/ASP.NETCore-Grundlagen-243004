using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieStore.Migrations
{
    /// <inheritdoc />
    public partial class InitMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMDBRating = table.Column<double>(type: "float", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "IMDBRating", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1L, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", 5, 8.5, "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg", 13.99m, "The Shawshank Redemption" },
                    { 2L, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 5, 7.5999999999999996, "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg", 19.99m, "The Godfather" },
                    { 3L, "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids.", 1, 9.0, "https://upload.wikimedia.org/wikipedia/en/0/0d/Jurassic_Park_Poster.jpg", 12.99m, "Jurassic Park" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
