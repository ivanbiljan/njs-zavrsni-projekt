using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Njs.Core.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "AQAAAAIAAYagAAAAELIG5gndRZO6rGKspQZoAfoMKMCvR0QsU2N8CilR1yw+9PjMG7itBsG0lDJZhwcOLw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "AQAAAAIAAYagAAAAECvcVsL5lTZOBBxz0sHKw7suqnQfXbc5CIql8TAoxaGzfuc60Ei7Bnl3Dkfi4mLbsA==");
        }
    }
}
