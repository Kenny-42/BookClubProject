using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Data.Configurations;

public class BooksConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.HasData(
            new Book {
                Id = 1,
                Title = "The Silent Library",
                Author = "Ava Miles",
                Description = "A suspenseful thriller set in an eerie town.",
                ISBN = "9780451491234"
            },
            new Book
            {
                Id = 2,
                Title = "Gardens of Glass",
                Author = "Liam Frost",
                Description = "A poetic journey through forgotten landscapes.",
                ISBN = "9780143110433"
            },
            new Book
            {
                Id = 3,
                Title = "Moonlight Archive",
                Author = "Elena Brook",
                Description = "A tale of lost civilizations and secret histories.",
                ISBN = "9780670022450"
            },
            new Book
            {
                Id = 4,
                Title = "Echoes of Dust",
                Author = "Mason Quinn",
                Description = "A gritty sci-fi about survival on a dying planet.",
                ISBN = "9780316095839"
            },
            new Book
            {
                Id = 5,
                Title = "Notes from the Attic",
                Author = "Harper Lee",
                Description = "Short stories and memories from a reclusive writer.",
                ISBN = "9780061120084"
            }
        );
    }
}
