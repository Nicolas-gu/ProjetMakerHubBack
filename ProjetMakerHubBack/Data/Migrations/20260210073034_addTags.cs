using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class addTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StepInstruction",
                table: "RecipeSteps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "SearchName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Végétarien", "vegetarien" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Vegan", "vegan" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Sans gluten", "sansgluten" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), "Sans lactose", "sanslactose" },
                    { new Guid("11111111-1111-1111-1111-111111111115"), "Healthy", "healthy" },
                    { new Guid("11111111-1111-1111-1111-111111111116"), "Protéiné", "proteine" },
                    { new Guid("11111111-1111-1111-1111-111111111117"), "Rapide", "rapide" },
                    { new Guid("11111111-1111-1111-1111-111111111118"), "Facile", "facile" },
                    { new Guid("11111111-1111-1111-1111-111111111119"), "Express", "express" },
                    { new Guid("11111111-1111-1111-1111-111111111120"), "Batch cooking", "batchcooking" },
                    { new Guid("11111111-1111-1111-1111-111111111121"), "Entrée", "entree" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), "Plat principal", "platprincipal" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), "Dessert", "dessert" },
                    { new Guid("11111111-1111-1111-1111-111111111124"), "Petit-déjeuner", "petitdejeuner" },
                    { new Guid("11111111-1111-1111-1111-111111111125"), "Apéritif", "aperitif" },
                    { new Guid("11111111-1111-1111-1111-111111111126"), "Italien", "italien" },
                    { new Guid("11111111-1111-1111-1111-111111111127"), "Asiatique", "asiatique" },
                    { new Guid("11111111-1111-1111-1111-111111111128"), "Mexicain", "mexicain" },
                    { new Guid("11111111-1111-1111-1111-111111111129"), "Traditionnel", "traditionnel" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"));

            migrationBuilder.AlterColumn<string>(
                name: "StepInstruction",
                table: "RecipeSteps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 14, 51, 18, 307, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 14, 51, 18, 307, DateTimeKind.Utc).AddTicks(282));
        }
    }
}
