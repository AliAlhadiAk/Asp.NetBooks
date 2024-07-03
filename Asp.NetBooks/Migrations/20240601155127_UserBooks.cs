using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetBooks.Migrations
{
    /// <inheritdoc />
    public partial class UserBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksUser",
                columns: table => new
                {
                    Books_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUser", x => new { x.Books_Id, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BooksUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUser_Books_Books_Id",
                        column: x => x.Books_Id,
                        principalTable: "Books",
                        principalColumn: "Books_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksUser_UsersId",
                table: "BooksUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksUser");
        }
    }
}
