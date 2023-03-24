using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().HasData(
                new Library()
                {
                    Id=1,
                    Name="Czerwień Rubinu",
                    Description="Książka o czarach",
                    Price=62,
                    AuthorName="Czesław Bogucin",
                    yearOfPublication=2012,
                    CreatedDate=DateTime.Now
                },
                new Library()
                {
                    Id=2,
                    Name="Opowieści z Narnii",
                    Description="Przygoda",
                    Price=50,
                    AuthorName="C.S Lewis",
                    yearOfPublication=1950,
                    CreatedDate=DateTime.Now
                },
                new Library()
                {
                    Id=3,
                    Name="Harry Potter",
                    Description="Książka o czarach",
                    Price=12,
                    AuthorName="J.K Rowling",
                    yearOfPublication=1987,
                    CreatedDate=DateTime.Now
                },
                new Library()
                {
                    Id=4,
                    Name="Solaris",
                    Description="Literatura piękna",
                    Price=99,
                    AuthorName="Stanisław Lem",
                    yearOfPublication=1876,
                    CreatedDate=DateTime.Now
                },
                new Library()
                {
                    Id=5,
                    Name="Gra o Tron",
                    Description="Walka o władze",
                    Price=2,
                    AuthorName="George  R.R. Martin",
                    yearOfPublication=1992,
                    CreatedDate=DateTime.Now
                });
                
        }
    }
}
