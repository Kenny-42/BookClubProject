using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "alice.smith@mail.com", "Alice", "Smith", "123456", "alice_smith" },
                    { 2, "bob.jones@mail.com", "Bob", "Jones", "123456", "bob_jones" },
                    { 3, "charlie.brown@mail.com", "Charlie", "Brown", "123456", "charlie_brown" },
                    { 4, "diana.white@mail.com", "Diana", "White", "123456", "diana_white" },
                    { 5, "ella.green@mail.com", "Ella", "Green", "123456", "ella_green" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { 1, "Ava Miles", "A suspenseful thriller set in an eerie town.", "9780451491234", "The Silent Library" },
                    { 2, "Liam Frost", "A poetic journey through forgotten landscapes.", "9780143110433", "Gardens of Glass" },
                    { 3, "Elena Brook", "A tale of lost civilizations and secret histories.", "9780670022450", "Moonlight Archive" },
                    { 4, "Mason Quinn", "A gritty sci-fi about survival on a dying planet.", "9780316095839", "Echoes of Dust" },
                    { 5, "Harper Lee", "Short stories and memories from a reclusive writer.", "9780061120084", "Notes from the Attic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
