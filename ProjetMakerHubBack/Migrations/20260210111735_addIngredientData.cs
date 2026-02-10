using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class addIngredientData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "SearchName" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2627), "Pâtes", "pates" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2630), "Riz", "riz" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2632), "Semoule", "semoule" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2634), "Poulet", "poulet" },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2636), "Thon", "thon" },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2637), "Oeufs", "oeufs" },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2639), "Tomates", "tomates" },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2641), "Oignon", "oignon" },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2642), "Ail", "ail" },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2644), "Poivron", "poivron" },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2646), "Carotte", "carotte" },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2646), "Courgette", "courgette" },
                    { new Guid("b0000000-0000-0000-0000-000000000013"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2678), "Champignons", "champignons" },
                    { new Guid("b0000000-0000-0000-0000-000000000014"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2680), "Huile d'olive", "huiledolive" },
                    { new Guid("b0000000-0000-0000-0000-000000000015"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2683), "Beurre", "beurre" },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2684), "Crème", "creme" },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2686), "Lait", "lait" },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2688), "Parmesan", "parmesan" },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2689), "Mozzarella", "mozzarella" },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2691), "Pesto", "pesto" },
                    { new Guid("b0000000-0000-0000-0000-000000000021"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2692), "Sauce tomate", "saucetomate" },
                    { new Guid("b0000000-0000-0000-0000-000000000022"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2694), "Sel", "sel" },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2696), "Poivre", "poivre" },
                    { new Guid("b0000000-0000-0000-0000-000000000024"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2697), "Paprika", "paprika" },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2699), "Cumin", "cumin" },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2701), "Citron", "citron" },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2702), "Miel", "miel" },
                    { new Guid("b0000000-0000-0000-0000-000000000028"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2704), "Haricots rouges", "haricotsrouges" },
                    { new Guid("b0000000-0000-0000-0000-000000000029"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2706), "Maïs", "mais" },
                    { new Guid("b0000000-0000-0000-0000-000000000030"), new DateTime(2026, 2, 10, 11, 17, 35, 612, DateTimeKind.Utc).AddTicks(2707), "Salade", "salade" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 11, 17, 35, 617, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 11, 17, 35, 617, DateTimeKind.Utc).AddTicks(682));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000030"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 11, 16, 53, 409, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 10, 11, 16, 53, 409, DateTimeKind.Utc).AddTicks(7444));
        }
    }
}
