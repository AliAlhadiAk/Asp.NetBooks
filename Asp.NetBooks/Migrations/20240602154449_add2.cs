using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetBooks.Migrations
{
    /// <inheritdoc />
    public partial class add2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddToCart_AspNetUsers_UserId",
                table: "AddToCart");

            migrationBuilder.DropIndex(
                name: "IX_AddToCart_UserId",
                table: "AddToCart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AddToCart");

            migrationBuilder.AlterColumn<string>(
                name: "User_id",
                table: "AddToCart",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_User_id",
                table: "AddToCart",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddToCart_AspNetUsers_User_id",
                table: "AddToCart",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddToCart_AspNetUsers_User_id",
                table: "AddToCart");

            migrationBuilder.DropIndex(
                name: "IX_AddToCart_User_id",
                table: "AddToCart");

            migrationBuilder.AlterColumn<Guid>(
                name: "User_id",
                table: "AddToCart",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AddToCart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_UserId",
                table: "AddToCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddToCart_AspNetUsers_UserId",
                table: "AddToCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
