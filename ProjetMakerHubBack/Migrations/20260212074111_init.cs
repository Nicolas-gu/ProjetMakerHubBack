using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetMakerHubBack.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PantryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PantryItems_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PantryItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BasePortion = table.Column<int>(type: "int", nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekStart = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Portion = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSlots_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanSlots_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: true),
                    QuantityText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    StepInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTags",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTags", x => new { x.RecipeId, x.TagId });
                    table.ForeignKey(
                        name: "FK_RecipeTags_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRecipes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecipes", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_UserRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRecipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedAt", "Name", "SearchName" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7101), "Pâtes", "pates" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7105), "Riz", "riz" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7108), "Semoule", "semoule" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7110), "Poulet", "poulet" },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7112), "Thon", "thon" },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7114), "Oeufs", "oeufs" },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7117), "Tomates", "tomates" },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7119), "Oignon", "oignon" },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7122), "Ail", "ail" },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7124), "Poivron", "poivron" },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7127), "Carotte", "carotte" },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7127), "Courgette", "courgette" },
                    { new Guid("b0000000-0000-0000-0000-000000000013"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7131), "Champignons", "champignons" },
                    { new Guid("b0000000-0000-0000-0000-000000000014"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7133), "Huile d'olive", "huiledolive" },
                    { new Guid("b0000000-0000-0000-0000-000000000015"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7135), "Beurre", "beurre" },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7137), "Crème", "creme" },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7139), "Lait", "lait" },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7141), "Parmesan", "parmesan" },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7143), "Mozzarella", "mozzarella" },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7145), "Pesto", "pesto" },
                    { new Guid("b0000000-0000-0000-0000-000000000021"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7147), "Sauce tomate", "saucetomate" },
                    { new Guid("b0000000-0000-0000-0000-000000000022"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7149), "Sel", "sel" },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7151), "Poivre", "poivre" },
                    { new Guid("b0000000-0000-0000-0000-000000000024"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7153), "Paprika", "paprika" },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7155), "Cumin", "cumin" },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7157), "Citron", "citron" },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7159), "Miel", "miel" },
                    { new Guid("b0000000-0000-0000-0000-000000000028"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7161), "Haricots rouges", "haricotsrouges" },
                    { new Guid("b0000000-0000-0000-0000-000000000029"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7163), "Maïs", "mais" },
                    { new Guid("b0000000-0000-0000-0000-000000000030"), new DateTime(2026, 2, 12, 7, 41, 8, 33, DateTimeKind.Utc).AddTicks(7167), "Salade", "salade" }
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "Email", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), new DateTime(2026, 2, 12, 7, 41, 8, 39, DateTimeKind.Utc).AddTicks(9745), "Usertest", "usertest@mail.com", "4988d3e3-2a76-48df-8a8f-d7353ac9811eq6ubEYi/cX9Zqf0Y7vQk3tR1rwn58Z0OFeP9sOIOg3AvkY9QA/eHAH2RHNw8OA+lBLhIWqFpRuuaKPpFBYydBQ==", 1 },
                    { new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), new DateTime(2026, 2, 12, 7, 41, 8, 39, DateTimeKind.Utc).AddTicks(9498), "Kooz", "kooz@mail.com", "1b813899-603a-40cf-a635-c56ef6363ca52sQKF7IwePtw1OwhdieKiZNTz7nsk3R7x6lnvoBUCQeW0L7DRSMGnLd0TdjxiDCKwvSJgbHZqMnSaQH5nFsZDw==", 2 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "BasePortion", "CookTime", "CreatedAt", "CreatedByUserId", "Description", "IsPublic", "PrepTime", "Title" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), 2, 10, new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9114), new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), "Classique rapide et efficace.", true, 5, "Pâtes au pesto" },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), 2, 15, new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9120), new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), "Parfait pour écouler le frigo.", true, 10, "Riz sauté au poulet" },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), 1, 8, new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9124), new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), "Simple, rapide, protéinée.", true, 5, "Omelette champignons-fromage" },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), 2, 0, new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9128), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Healthy et frais.", true, 10, "Salade thon maïs citron" },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), 3, 20, new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9132), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Version simple sans prise de tête.", true, 10, "Chili rapide" },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), 2, 15, new DateTime(2026, 2, 12, 7, 41, 8, 37, DateTimeKind.Utc).AddTicks(9136), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Sucré-salé facile.", true, 10, "Poulet miel-citron" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "BaseQuantity", "QuantityText", "Unit" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000001"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000001"), 20m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new Guid("c0000000-0000-0000-0000-000000000001"), 60m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000002"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new Guid("c0000000-0000-0000-0000-000000000002"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new Guid("c0000000-0000-0000-0000-000000000002"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new Guid("c0000000-0000-0000-0000-000000000002"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), new Guid("c0000000-0000-0000-0000-000000000003"), 3m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000013"), new Guid("c0000000-0000-0000-0000-000000000003"), 150m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000003"), 80m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new Guid("c0000000-0000-0000-0000-000000000004"), 160m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000004"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000029"), new Guid("c0000000-0000-0000-0000-000000000004"), 120m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000030"), new Guid("c0000000-0000-0000-0000-000000000004"), 1m, "1 bol", 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new Guid("c0000000-0000-0000-0000-000000000005"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new Guid("c0000000-0000-0000-0000-000000000005"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000021"), new Guid("c0000000-0000-0000-0000-000000000005"), 300m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), new Guid("c0000000-0000-0000-0000-000000000005"), null, "1 c.à.c", 0 },
                    { new Guid("b0000000-0000-0000-0000-000000000028"), new Guid("c0000000-0000-0000-0000-000000000005"), 240m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000029"), new Guid("c0000000-0000-0000-0000-000000000005"), 120m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new Guid("c0000000-0000-0000-0000-000000000006"), 250m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000006"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), new Guid("c0000000-0000-0000-0000-000000000006"), 1m, null, 7 }
                });

            migrationBuilder.InsertData(
                table: "RecipeSteps",
                columns: new[] { "Id", "RecipeId", "StepInstruction", "StepNumber" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000001"), "Cuire les pâtes dans l'eau salée.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000001"), "Égoutter, ajouter le pesto et mélanger.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000003"), new Guid("c0000000-0000-0000-0000-000000000002"), "Faire revenir oignon et ail dans l'huile.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000004"), new Guid("c0000000-0000-0000-0000-000000000002"), "Ajouter le poulet, cuire puis ajouter le riz et assaisonner.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000005"), new Guid("c0000000-0000-0000-0000-000000000003"), "Battre les œufs avec sel et poivre.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000006"), new Guid("c0000000-0000-0000-0000-000000000003"), "Cuire les champignons, ajouter les œufs et le fromage.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000007"), new Guid("c0000000-0000-0000-0000-000000000004"), "Mélanger salade, thon et maïs.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000008"), new Guid("c0000000-0000-0000-0000-000000000004"), "Assaisonner avec citron, huile d'olive, sel et poivre.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000009"), new Guid("c0000000-0000-0000-0000-000000000005"), "Faire revenir oignon et poivron.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000010"), new Guid("c0000000-0000-0000-0000-000000000005"), "Ajouter sauce tomate, haricots, maïs et épices, mijoter.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000011"), new Guid("c0000000-0000-0000-0000-000000000006"), "Faire dorer le poulet dans un peu d'huile.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000012"), new Guid("c0000000-0000-0000-0000-000000000006"), "Ajouter miel + citron, laisser réduire et assaisonner.", 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111117") },
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111118") },
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111126") },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111118") },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111127") },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111116") },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new Guid("11111111-1111-1111-1111-111111111117") },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111115") },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new Guid("11111111-1111-1111-1111-111111111117") },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), new Guid("11111111-1111-1111-1111-111111111128") },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), new Guid("11111111-1111-1111-1111-111111111118") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_SearchName",
                table: "Ingredients",
                column: "SearchName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PantryItems_IngredientId",
                table: "PantryItems",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PantryItems_UserId",
                table: "PantryItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSlots_PlanId",
                table: "PlanSlots",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSlots_RecipeId",
                table: "PlanSlots",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatedByUserId",
                table: "Recipes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_TagId",
                table: "RecipeTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_IngredientId",
                table: "ShoppingListItems",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipes_RecipeId",
                table: "UserRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PantryItems");

            migrationBuilder.DropTable(
                name: "PlanSlots");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "RecipeTags");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropTable(
                name: "UserRecipes");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
