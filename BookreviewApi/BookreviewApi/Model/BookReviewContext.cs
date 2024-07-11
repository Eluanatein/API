using Microsoft.EntityFrameworkCore;
using BookreviewApi.Model;

namespace BookreviewApi.Model
{
   
    public class BookReviewContext : DbContext
    {
        // Constructor that accepts DbContextOptions and passes them to the base class constructor
        public BookReviewContext(DbContextOptions<BookReviewContext> options) : base(options) { }

        
        public DbSet<BOOK> Books { get; set; }
        public DbSet<USER> Users { get; set; }
        public DbSet<RATING> Ratings { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<USER>()
                .HasMany(u => u.RATINGS)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

      
            modelBuilder.Entity<BOOK>()
                .HasMany(b => b.RATINGS)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);
            modelBuilder.Seed();
        }
    }
}