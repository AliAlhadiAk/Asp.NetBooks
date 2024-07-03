﻿// <auto-generated />
using System;
using Asp.NetBooks.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asp.NetBooks.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601173219_Inital9")]
    partial class Inital9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Asp.NetBooks.Model.Books", b =>
                {
                    b.Property<string>("Books_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<double>("Rental_Price")
                        .HasColumnType("float");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Books_Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Books_Id = "1",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "Over Clouds",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = "https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "2",
                            Author = "Eman Ramdan",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "Python Developer",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71ALZyWoRiL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "3",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "Financial Suuces",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = "https://m.media-amazon.com/images/I/713KfGkrIlL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "4",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "Eman Ramdan Superstitions",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71wiPj9w1KL._AC_UY218_.jpg\r\n",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "5",
                            Author = "Al5aaal",
                            Description = "description",
                            Name = "Nabih Berri a2wa Zalame",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "6",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71txyr9Vj6L._AC_UY218_.jpg\r\n",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "7",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "8",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71hSA4odCmL._AC_UY218_.jpg\r\n",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "9",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "10",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/619ZUIo+baL._AC_UY218_.jpg\r\n",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "11",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = "https://m.media-amazon.com/images/I/71fjW0vIOoL._AC_UY218_.jpg",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "12",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = " https://m.media-amazon.com/images/I/715wbLGtFqL._AC_UY218_.jpg\r\n",
                            language = "English"
                        },
                        new
                        {
                            Books_Id = "13",
                            Author = "Al5aaal",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Name = "name",
                            Price = 30.0,
                            QuantityAvailable = 13,
                            Rental_Price = 12.43,
                            Url = "https://m.media-amazon.com/images/I/91ERdzWjBeL._AC_UY218_.jpg\r\n",
                            language = "English"
                        });
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Book_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Book_id")
                        .IsUnique();

                    b.HasIndex("User_Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Book_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Book_id");

                    b.ToTable("Invenntory");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.PurchaseBooks", b =>
                {
                    b.Property<int>("Purchase_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Purchase_Id"));

                    b.Property<string>("Books_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("PricePaid")
                        .HasColumnType("float");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Purchase_Id");

                    b.HasIndex("Books_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("PurchaseBooks");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.RentBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Books_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Books_id");

                    b.HasIndex("User_id");

                    b.ToTable("RentBooks");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BooksUser", b =>
                {
                    b.Property<string>("Books_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Books_Id", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("BooksUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Cart", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.User", null)
                        .WithMany("Carts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Favorites", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.Books", "Books")
                        .WithOne("Favorites")
                        .HasForeignKey("Asp.NetBooks.Model.Favorites", "Book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.NetBooks.Model.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Inventory", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.Books", "Books")
                        .WithMany("Inventories")
                        .HasForeignKey("Book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.PurchaseBooks", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.Books", "Books")
                        .WithMany("PurchaseBooks")
                        .HasForeignKey("Books_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.NetBooks.Model.User", "User")
                        .WithMany("PurchaseBooks")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.RentBooks", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.Books", "Books")
                        .WithMany("RentBooks")
                        .HasForeignKey("Books_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.NetBooks.Model.User", "User")
                        .WithMany("RentBooks")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksUser", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.Books", null)
                        .WithMany()
                        .HasForeignKey("Books_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.NetBooks.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.NetBooks.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Asp.NetBooks.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp.NetBooks.Model.Books", b =>
                {
                    b.Navigation("Favorites")
                        .IsRequired();

                    b.Navigation("Inventories");

                    b.Navigation("PurchaseBooks");

                    b.Navigation("RentBooks");
                });

            modelBuilder.Entity("Asp.NetBooks.Model.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Favorites");

                    b.Navigation("PurchaseBooks");

                    b.Navigation("RentBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
