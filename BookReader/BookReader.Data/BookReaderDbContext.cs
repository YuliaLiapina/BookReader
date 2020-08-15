using BookReader.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BookReader.Data
{
    public class BookReaderDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookReaderDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
            .HasMany(x => x.WishLists)
            .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
           .HasMany(x => x.Genres)
           .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
           .HasMany(x => x.Users)
           .WithMany(x => x.Books);

            modelBuilder.Entity<WishList>()
           .HasRequired(x => x.User)
           .WithMany(x => x.WishLists)
           .HasForeignKey(x => x.UserId);
        }
        public static BookReaderDbContext Create()
        {
            return new BookReaderDbContext();
        }
    }
}
