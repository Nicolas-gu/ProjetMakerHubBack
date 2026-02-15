using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuantityText",
                table: "ShoppingListItems",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityText",
                table: "ShoppingListItems");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000028"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 39, DateTimeKind.Utc).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 7, 41, 8, 39, DateTimeKind.Utc).AddTicks(9498));
        }
    }
}
