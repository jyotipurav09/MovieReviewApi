using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCodeToTokenInEmailVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "PasswordResetTokens",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "EmailVerifications",
                newName: "Token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "PasswordResetTokens",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "EmailVerifications",
                newName: "Code");
        }
    }
}
