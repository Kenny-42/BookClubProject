using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BookClub.Data.Configurations;

public class ReviewsConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        // Configure Id to be auto-generated on add
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        // Set default value for CreatedAt to current UTC time
        builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Seed initial data
        builder.HasData(
            new Review {
                Id = 1,
                AccountId = 1,
                BookId = 1,
                Rating = 4,
                Comment = "Really enjoyed the suspense and pacing."
            },
            new Review {
                Id = 2,
                AccountId = 2,
                BookId = 1,
                Rating = 5,
                Comment = "An instant favorite. Couldn’t put it down!"
            },
            new Review {
                Id = 3,
                AccountId = 3,
                BookId = 2,
                Rating = 3,
                Comment = "Good writing, but not my genre."
            },
            new Review
            {
                Id = 4,
                AccountId = 4,
                BookId = 3,
                Rating = 4,
                Comment = "Loved the historical depth."
            },
            new Review
            {
                Id = 5,
                AccountId = 5,
                BookId = 4,
                Rating = 2,
                Comment = "Interesting premise, but slow in parts."
            },
            new Review
            {
                Id = 6,
                AccountId = 2,
                BookId = 5,
                Rating = 5,
                Comment = "Beautifully written and moving."
            },
            new Review
            {
                Id = 7,
                AccountId = 1,
                BookId = 3,
                Rating = 4,
                Comment = "Kept me engaged from start to finish."
            },
            new Review
            {
                Id = 8,
                AccountId = 3,
                BookId = 4,
                Rating = 5,
                Comment = "Incredible worldbuilding and emotion."
            },
            new Review
            {
                Id = 9,
                AccountId = 4,
                BookId = 2,
                Rating = 3,
                Comment = "Could use a stronger plot, but decent."
            },
            new Review
            {
                Id = 10,
                AccountId = 5,
                BookId = 5,
                Rating = 4,
                Comment = "Great for a weekend read!"
            }
        );
    }
}
