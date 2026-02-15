using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000028"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 702, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 20, 58, 716, DateTimeKind.Utc).AddTicks(4349), null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 20, 58, 716, DateTimeKind.Utc).AddTicks(4363), null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 20, 58, 716, DateTimeKind.Utc).AddTicks(4373), null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 20, 58, 716, DateTimeKind.Utc).AddTicks(4382), null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 20, 58, 716, DateTimeKind.Utc).AddTicks(4392), null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 2, 15, 13, 20, 58, 716, DateTimeKind.Utc).AddTicks(4401), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 722, DateTimeKind.Utc).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 15, 13, 20, 58, 722, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListId_IngredientId_Unit",
                table: "ShoppingListItems",
                columns: new[] { "ShoppingListId", "IngredientId", "Unit" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingListItems_ShoppingListId_IngredientId_Unit",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000028"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 576, DateTimeKind.Utc).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 580, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 580, DateTimeKind.Utc).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 580, DateTimeKind.Utc).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 580, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 580, DateTimeKind.Utc).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 580, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 581, DateTimeKind.Utc).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 14, 20, 26, 17, 581, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId");
        }
    }
}
