using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalSolution.Migrations
{
    /// <inheritdoc />
    public partial class BlogCC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa692445-a241-4bef-9f9d-aeec35c4bfcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f85de867-4985-4704-b149-9dd4443228f1", "AQAAAAIAAYagAAAAEFLFhlMtNLOnTXsRepV+hlIOGWDht+llfIQXVzNvwzi5kcoiV0Gg/9Jzu5Aka4QHBw==", "4743455f-3b5b-4870-9c09-77409b0f29ee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa692445-a241-4bef-9f9d-aeec35c4bfcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55a5f6df-bb2d-4ffb-9bc9-c57df3609dc5", "AQAAAAIAAYagAAAAEBt5ZVqyEnhTKHdAiQ65wbEgxrYMbUmyQHwJoFL4SeOCkRJofl3QMj6adJRt6H5UXQ==", "2184bf0c-c414-4dc7-8d5f-5221f2ed19d6" });
        }
    }
}
