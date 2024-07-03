using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asp.NetBooks.Migrations
{
    /// <inheritdoc />
    public partial class Initial5666 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Books_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rental_Price = table.Column<double>(type: "float", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Books_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Books_Book_id",
                        column: x => x.Book_id,
                        principalTable: "Books",
                        principalColumn: "Books_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invenntory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invenntory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invenntory_Books_Book_id",
                        column: x => x.Book_id,
                        principalTable: "Books",
                        principalColumn: "Books_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseBooks",
                columns: table => new
                {
                    Purchase_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Books_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePaid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseBooks", x => x.Purchase_Id);
                    table.ForeignKey(
                        name: "FK_PurchaseBooks_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseBooks_Books_Books_Id",
                        column: x => x.Books_Id,
                        principalTable: "Books",
                        principalColumn: "Books_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Books_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentBooks_AspNetUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentBooks_Books_Books_id",
                        column: x => x.Books_id,
                        principalTable: "Books",
                        principalColumn: "Books_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Books_Id", "Author", "Description", "Name", "Price", "QuantityAvailable", "Rental_Price", "Url", "language" },
                values: new object[,]
                {
                    { "1", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "Over Clouds", 30.0, 13, 12.43, "https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg", "English" },
                    { "10", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/619ZUIo+baL._AC_UY218_.jpg\r\n", "English" },
                    { "11", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, "https://m.media-amazon.com/images/I/71fjW0vIOoL._AC_UY218_.jpg", "English" },
                    { "12", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/715wbLGtFqL._AC_UY218_.jpg\r\n", "English" },
                    { "13", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, "https://m.media-amazon.com/images/I/91ERdzWjBeL._AC_UY218_.jpg\r\n", "English" },
                    { "2", "Eman Ramdan", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "Python Developer", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71ALZyWoRiL._AC_UY218_.jpg", "English" },
                    { "3", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, "https://m.media-amazon.com/images/I/713KfGkrIlL._AC_UY218_.jpg", "English" },
                    { "4", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71wiPj9w1KL._AC_UY218_.jpg\r\n", "English" },
                    { "5", "Al5aaal", "description", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg", "English" },
                    { "6", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71txyr9Vj6L._AC_UY218_.jpg\r\n", "English" },
                    { "7", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg", "English" },
                    { "8", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71hSA4odCmL._AC_UY218_.jpg\r\n", "English" },
                    { "9", "Al5aaal", "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life", "name", 30.0, 13, 12.43, " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg", "English" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Book_id",
                table: "Favorites",
                column: "Book_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_User_Id",
                table: "Favorites",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invenntory_Book_id",
                table: "Invenntory",
                column: "Book_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBooks_Books_Id",
                table: "PurchaseBooks",
                column: "Books_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBooks_User_Id",
                table: "PurchaseBooks",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooks_Books_id",
                table: "RentBooks",
                column: "Books_id");

            migrationBuilder.CreateIndex(
                name: "IX_RentBooks_User_id",
                table: "RentBooks",
                column: "User_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Invenntory");

            migrationBuilder.DropTable(
                name: "PurchaseBooks");

            migrationBuilder.DropTable(
                name: "RentBooks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
