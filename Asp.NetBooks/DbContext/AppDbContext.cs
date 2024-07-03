using Asp.NetBooks.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetBooks.DbContext
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
        public DbSet<Inventory> Invenntory { get; set; }
        public DbSet<RentBooks> RentBooks { get; set; }
        public DbSet<PurchaseBooks> PurchaseBooks { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<AddToCart> AddToCart { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
           .HasMany(b => b.Inventories)
           .WithOne(i => i.Books)
           .HasForeignKey(i => i.Book_id);

            modelBuilder.Entity<Books>()
                .HasMany(b => b.RentBooks)
                .WithOne(rb => rb.Books)
                .HasForeignKey(rb => rb.Books_id);

            modelBuilder.Entity<Books>()
                .HasMany(b => b.PurchaseBooks)
                .WithOne(pb => pb.Books)
                .HasForeignKey(pb => pb.Books_Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.RentBooks)
                .WithOne(rb => rb.User)
                .HasForeignKey(rb => rb.User_id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.PurchaseBooks)
                .WithOne(pb => pb.User)
                .HasForeignKey(pb => pb.User_Id);


            modelBuilder.Entity<Books>()
                .HasData(

                new Books
                {
                    Books_Id = "1",
                    Name = "Over Clouds",
                    Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                    Url = "https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                    Author = "Al5aaal",
                    QuantityAvailable = 13,
                    Price = 30.00,
                    Rental_Price = 12.43,
                    language = "English",

                },
                 new Books
                 {
                     Books_Id = "2",

                     Name = "Python Developer",
                     Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                     Url = " https://m.media-amazon.com/images/I/71ALZyWoRiL._AC_UY218_.jpg",
                     Author = "Eman Ramdan",
                     QuantityAvailable = 13,
                     Price = 30.00,
                     Rental_Price = 12.43,
                     language = "English"

                 },
                  new Books
                  {

                      Books_Id = "3",

                      Name = "Financial Suuces",
                      Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                      Url = "https://m.media-amazon.com/images/I/713KfGkrIlL._AC_UY218_.jpg",
                      Author = "Al5aaal",
                      QuantityAvailable = 13,
                      Price = 30.00,
                      Rental_Price = 12.43,
                      language = "English"

                  },

                    new Books
                    {
                        Books_Id = "4",
                        Name = "Eman Ramdan Superstitions",
                        Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                        Url = " https://m.media-amazon.com/images/I/71wiPj9w1KL._AC_UY218_.jpg\r\n",
                        Author = "Al5aaal",
                        QuantityAvailable = 13,
                        Price = 30.00,
                        Rental_Price = 12.43,
                        language = "English"

                    },
                     new Books
                     {
                         Books_Id = "5",
                         Name = "Nabih Berri a2wa Zalame",
                         Description = "description",
                         Url = " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                         Author = "Al5aaal",
                         QuantityAvailable = 13,
                         Price = 30.00,
                         Rental_Price = 12.43,
                         language = "English"

                     },
                      new Books
                      {

                          Books_Id = "6",

                          Name = "name",
                          Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                          Url = " https://m.media-amazon.com/images/I/71txyr9Vj6L._AC_UY218_.jpg\r\n",
                          Author = "Al5aaal",
                          QuantityAvailable = 13,
                          Price = 30.00,
                          Rental_Price = 12.43,
                          language = "English"

                      },
                       new Books
                       {
                          Books_Id = "7",

                           Name = "name",
                           Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                           Url = " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                           Author = "Al5aaal",
                           QuantityAvailable = 13,
                           Price = 30.00,
                           Rental_Price = 12.43,
                           language = "English"

                       },
                        new Books
                        {
                            Books_Id = "8",

                            Name = "name",
                            Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                            Url = " https://m.media-amazon.com/images/I/71hSA4odCmL._AC_UY218_.jpg\r\n",
                            Author = "Al5aaal",
                            QuantityAvailable = 13,
                            Price = 30.00,
                            Rental_Price = 12.43,
                            language = "English"

                        },
                         new Books
                         {
                             Books_Id = "9",

                             Name = "name",
                             Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                             Url = " https://m.media-amazon.com/images/I/71pslAmiZHL._AC_UY218_.jpg",
                             Author = "Al5aaal",
                             QuantityAvailable = 13,
                             Price = 30.00,
                             Rental_Price = 12.43,
                             language = "English"

                         },
                          new Books
                          {
                              Books_Id = "10",

                              Name = "name",
                              Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                              Url = " https://m.media-amazon.com/images/I/619ZUIo+baL._AC_UY218_.jpg\r\n",
                              Author = "Al5aaal",
                              QuantityAvailable = 13,
                              Price = 30.00,
                              Rental_Price = 12.43,
                              language = "English"

                          },
                           new Books
                           {
                               Books_Id = "11",

                               Name = "name",
                               Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                               Url = "https://m.media-amazon.com/images/I/71fjW0vIOoL._AC_UY218_.jpg",
                               Author = "Al5aaal",
                               QuantityAvailable = 13,
                               Price = 30.00,
                               Rental_Price = 12.43,
                               language = "English"

                           },
                            new Books
                            {
                                Books_Id = "12",

                                Name = "name",
                                Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                                Url = " https://m.media-amazon.com/images/I/715wbLGtFqL._AC_UY218_.jpg\r\n",
                                Author = "Al5aaal",
                                QuantityAvailable = 13,
                                Price = 30.00,
                                Rental_Price = 12.43,
                                language = "English"

                            },
                            new Books
                            {
                                Books_Id = "13",

                                Name = "name",

                                Description = "This book has alot of trouble and interresting features talikng about a man that can fly over the clouds making whishes come true with a small monkeys paw that destriyed then the seargent life",
                                Url = "https://m.media-amazon.com/images/I/91ERdzWjBeL._AC_UY218_.jpg\r\n",
                                Author = "Al5aaal",
                                QuantityAvailable = 13,
                                Price = 30.00,
                                Rental_Price = 12.43,
                                language = "English"

                            }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
