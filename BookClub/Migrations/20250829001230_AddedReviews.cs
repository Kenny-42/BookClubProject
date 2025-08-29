using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookClub.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "Id", "AccountId", "BookId", "Comment", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, "Really enjoyed the suspense and pacing.", 4 },
                    { 2, 2, 1, "An instant favorite. Couldn’t put it down!", 5 },
                    { 3, 3, 2, "Good writing, but not my genre.", 3 },
                    { 4, 4, 3, "Loved the historical depth.", 4 },
                    { 5, 5, 4, "Interesting premise, but slow in parts.", 2 },
                    { 6, 2, 5, "Beautifully written and moving.", 5 },
                    { 7, 1, 3, "Kept me engaged from start to finish.", 4 },
                    { 8, 3, 4, "Incredible worldbuilding and emotion.", 5 },
                    { 9, 4, 2, "Could use a stronger plot, but decent.", 3 },
                    { 10, 5, 5, "Great for a weekend read!", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "Id");
        }
    }
}
