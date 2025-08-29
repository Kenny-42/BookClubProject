using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Data.Configurations;

public class DiscussionsConfiguration : IEntityTypeConfiguration<Discussion>
{
    public void Configure(EntityTypeBuilder<Discussion> builder)
    {
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.PostedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasData(
            // Book 1 - The Silent Library
            new Discussion
            {
                Id = 1,
                BookId = 1,
                AccountId = 1, // Emma
                Comment = "The twist at the end completely caught me off guard. Anyone else?",
                PostedAt = new DateTime(2025, 8, 20, 14, 0, 0)
            },
            new Discussion
            {
                Id = 2,
                BookId = 1,
                AccountId = 2, // Liam
                Comment = "Totally! I had to go back a few chapters to see if there were clues.",
                PostedAt = new DateTime(2025, 8, 20, 14, 15, 0)
            },
            new Discussion
            {
                Id = 3,
                BookId = 1,
                AccountId = 5, // Ava
                Comment = "Same here. The author did a great job of hiding it in plain sight.",
                PostedAt = new DateTime(2025, 8, 20, 14, 45, 0)
            },

            // Book 2 - Gardens of Glass
            new Discussion
            {
                Id = 4,
                BookId = 2,
                AccountId = 3, // Sophia
                Comment = "Some parts felt like poetry. Did anyone else highlight passages?",
                PostedAt = new DateTime(2025, 8, 21, 10, 10, 0)
            },
            new Discussion
            {
                Id = 5,
                BookId = 2,
                AccountId = 4, // Noah
                Comment = "Yes! The line about 'shattered reflections of memory' stuck with me.",
                PostedAt = new DateTime(2025, 8, 21, 10, 32, 0)
            },

            // Book 3 - Moonlight Archive
            new Discussion
            {
                Id = 6,
                BookId = 3,
                AccountId = 2, // Liam
                Comment = "Do you think the Archive was real or metaphorical?",
                PostedAt = new DateTime(2025, 8, 22, 16, 5, 0)
            },
            new Discussion
            {
                Id = 7,
                BookId = 3,
                AccountId = 1, // Emma
                Comment = "I took it as metaphorical — like a memory palace. But I could be wrong.",
                PostedAt = new DateTime(2025, 8, 22, 16, 25, 0)
            },
            new Discussion
            {
                Id = 8,
                BookId = 3,
                AccountId = 3, // Sophia
                Comment = "That's what made it fun — it’s open to interpretation!",
                PostedAt = new DateTime(2025, 8, 22, 16, 40, 0)
            },

            // Book 4 - Echoes of Dust
            new Discussion
            {
                Id = 9,
                BookId = 4,
                AccountId = 5, // Ava
                Comment = "The planet reminded me of early Mars theories. Was it based on something real?",
                PostedAt = new DateTime(2025, 8, 23, 9, 0, 0)
            },
            new Discussion
            {
                Id = 10,
                BookId = 4,
                AccountId = 4, // Noah
                Comment = "I think the author mentioned in an interview it was inspired by abandoned mining towns.",
                PostedAt = new DateTime(2025, 8, 23, 9, 30, 0)
            },

            // Book 5 - Notes from the Attic
            new Discussion
            {
                Id = 11,
                BookId = 5,
                AccountId = 1, // Emma
                Comment = "The short story about the photograph made me tear up. So personal.",
                PostedAt = new DateTime(2025, 8, 24, 11, 15, 0)
            },
            new Discussion
            {
                Id = 12,
                BookId = 5,
                AccountId = 3, // Sophia
                Comment = "That was my favorite too. It felt like reading someone’s diary.",
                PostedAt = new DateTime(2025, 8, 24, 11, 50, 0)
            }
        );
    }
}
