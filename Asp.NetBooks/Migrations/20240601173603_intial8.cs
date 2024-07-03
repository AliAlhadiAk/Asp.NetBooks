using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetBooks.Migrations
{
    /// <inheritdoc />
    public partial class intial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_Book_id",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Book_id",
                table: "Favorites",
                column: "Book_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_Book_id",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Book_id",
                table: "Favorites",
                column: "Book_id",
                unique: true);
        }
    }
}
