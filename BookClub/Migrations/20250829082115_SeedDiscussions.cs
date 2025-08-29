using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClub.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiscussions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "AccountId", "BookId", "Comment" },
                values: new object[,]
                {
                    { 1, 1, 1, "The twist at the end completely caught me off guard. Anyone else?" },
                    { 2, 2, 1, "Totally! I had to go back a few chapters to see if there were clues." },
                    { 3, 5, 1, "Same here. The author did a great job of hiding it in plain sight." },
                    { 4, 3, 2, "Some parts felt like poetry. Did anyone else highlight passages?" },
                    { 5, 4, 2, "Yes! The line about 'shattered reflections of memory' stuck with me." },
                    { 6, 2, 3, "Do you think the Archive was real or metaphorical?" },
                    { 7, 1, 3, "I took it as metaphorical — like a memory palace. But I could be wrong." },
                    { 8, 3, 3, "That's what made it fun — it’s open to interpretation!" },
                    { 9, 5, 4, "The planet reminded me of early Mars theories. Was it based on something real?" },
                    { 10, 4, 4, "I think the author mentioned in an interview it was inspired by abandoned mining towns." },
                    { 11, 1, 5, "The short story about the photograph made me tear up. So personal." },
                    { 12, 3, 5, "That was my favorite too. It felt like reading someone’s diary." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discussions");
        }
    }
}
