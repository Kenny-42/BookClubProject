using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClub.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBirthdateCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Birthdate_AgeRange",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Birthdate_AgeRange",
                table: "Accounts",
                sql: "Birthdate <= DATEADD(YEAR, -13, GETDATE()) AND Birthdate >= DATEADD(YEAR, -100, GETDATE())");
        }
    }
}
