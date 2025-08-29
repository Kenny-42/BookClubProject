using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Data.Configurations;

public class AccountsConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.HasData(
            new Account {
                Id = 1,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@mail.com",
                Username = "alice_smith",
                Password = "123456"
            },
            new Account {
                Id = 2,
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob.jones@mail.com",
                Username = "bob_jones",
                Password = "123456"
            },
            new Account {
                Id = 3,
                FirstName = "Charlie",
                LastName = "Brown",
                Email = "charlie.brown@mail.com",
                Username = "charlie_brown",
                Password = "123456"
            },
            new Account {
                Id = 4,
                FirstName = "Diana",
                LastName = "White",
                Email = "diana.white@mail.com",
                Username = "diana_white",
                Password = "123456"
            },
            new Account {
                Id = 5,
                FirstName = "Ella",
                LastName = "Green",
                Email = "ella.green@mail.com",
                Username = "ella_green",
                Password = "123456"
            }
        );
    }
}
