using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetBooks.Migrations
{
    /// <inheritdoc />
    public partial class Inital9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cart",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Cart",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "CartUser",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartUser", x => new { x.CartsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CartUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartUser_Cart_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartUser_UsersId",
                table: "CartUser",
                column: "UsersId");
        }
    }
}
