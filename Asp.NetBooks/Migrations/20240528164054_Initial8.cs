using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetBooks.Migrations
{
    /// <inheritdoc />
    public partial class Initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Books_Id",
                keyValue: "3",
                column: "Name",
                value: "Financial Suuces");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Books_Id",
                keyValue: "4",
                column: "Name",
                value: "Eman Ramdan Superstitions");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Books_Id",
                keyValue: "5",
                column: "Name",
                value: "Nabih Berri a2wa Zalame");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Books_Id",
                keyValue: "3",
                column: "Name",
                value: "name");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Books_Id",
                keyValue: "4",
                column: "Name",
                value: "name");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Books_Id",
                keyValue: "5",
                column: "Name",
                value: "name");
        }
    }
}
