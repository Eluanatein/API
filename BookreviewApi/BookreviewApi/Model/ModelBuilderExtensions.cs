using Microsoft.EntityFrameworkCore;
using BookreviewApi.Model;

namespace BookreviewApi.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOOK>().HasData(
                new BOOK { Id = 1, Title = "Harry Potter", Datepublished = new DateTime(2007, 7, 1) },
                new BOOK { Id = 2, Title = "The Boys", Datepublished = new DateTime(1996, 12, 3) },
                new BOOK { Id = 3, Title = "Invincible", Datepublished = new DateTime(2002, 8, 6) }
            );

            modelBuilder.Entity<USER>().HasData(
               new USER { Id = 1, Username = "mark" },
               new USER { Id = 2, Username = "john" },
               new USER { Id = 3, Username = "goku" }
            );

            modelBuilder.Entity<RATING>().HasData(
                new RATING { Id = 1, DatePublished = DateTime.Now, Rating = 5, UserId = 1, BookId = 1 },
                new RATING { Id = 2, DatePublished = DateTime.Now, Rating = 4, UserId = 2, BookId = 2 },
                new RATING { Id = 3, DatePublished = DateTime.Now, Rating = 3, UserId = 3, BookId = 3 }
            );
        }
    }
}