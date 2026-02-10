using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class IsUniqueIngredientConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 8, 11, 31, 166, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 8, 11, 31, 166, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_SearchName",
                table: "Ingredients",
                column: "SearchName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingredients_SearchName",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 7, 30, 33, 957, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 7, 30, 33, 957, DateTimeKind.Utc).AddTicks(3677));
        }
    }
}
