using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class updatepwd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 6, 14, 51, 18, 307, DateTimeKind.Utc).AddTicks(509), "4988d3e3-2a76-48df-8a8f-d7353ac9811eq6ubEYi/cX9Zqf0Y7vQk3tR1rwn58Z0OFeP9sOIOg3AvkY9QA/eHAH2RHNw8OA+lBLhIWqFpRuuaKPpFBYydBQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 6, 14, 51, 18, 307, DateTimeKind.Utc).AddTicks(282), "1b813899-603a-40cf-a635-c56ef6363ca52sQKF7IwePtw1OwhdieKiZNTz7nsk3R7x6lnvoBUCQeW0L7DRSMGnLd0TdjxiDCKwvSJgbHZqMnSaQH5nFsZDw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 6, 13, 46, 10, 290, DateTimeKind.Utc).AddTicks(122), "1234" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 6, 13, 46, 10, 290, DateTimeKind.Utc).AddTicks(104), "1234" });
        }
    }
}
