using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class addusertest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "Email", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), new DateTime(2026, 2, 6, 13, 46, 10, 290, DateTimeKind.Utc).AddTicks(122), "Usertest", "usertest@mail.com", "1234", 1 },
                    { new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), new DateTime(2026, 2, 6, 13, 46, 10, 290, DateTimeKind.Utc).AddTicks(104), "Kooz", "kooz@mail.com", "1234", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
