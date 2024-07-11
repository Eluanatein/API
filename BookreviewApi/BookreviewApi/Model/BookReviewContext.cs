using Microsoft.EntityFrameworkCore;

namespace BookreviewApi.Model
{
   
    public class BookReviewContext : DbContext
    {
        public BookReviewContext(DbContextOptions<BookReviewContext> options) : base(options) { }

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
        public DbSet<BOOK> Books { get; set; }
        public DbSet<USER> Users { get; set; }
        public DbSet<RATING> Ratings { get; set; }

    }
}