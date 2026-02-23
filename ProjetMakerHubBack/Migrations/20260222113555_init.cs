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
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    QuantityText = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Pâtes", "pates" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Riz", "riz" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Quinoa", "quinoa" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Boulgour", "boulgour" },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Tortillas", "tortillas" },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Poulet", "poulet" },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Thon", "thon" },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Bœuf haché", "boeufhache" },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Saumon", "saumon" },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Œufs", "oeufs" },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Tofu", "tofu" },
                    { new Guid("b0000000-0000-0000-0000-000000000013"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Haricots rouges", "haricotsrouges" },
                    { new Guid("b0000000-0000-0000-0000-000000000014"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Pois chiches", "poischiches" },
                    { new Guid("b0000000-0000-0000-0000-000000000015"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Lentilles", "lentilles" },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Oignon", "oignon" },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Ail", "ail" },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Tomate", "tomate" },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Tomates concassées", "tomatesconcassees" },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Concentré de tomate", "concentredetomate" },
                    { new Guid("b0000000-0000-0000-0000-000000000021"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Carotte", "carotte" },
                    { new Guid("b0000000-0000-0000-0000-000000000022"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Courgette", "courgette" },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Poivron", "poivron" },
                    { new Guid("b0000000-0000-0000-0000-000000000024"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Champignons", "champignons" },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Épinards", "epinards" },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Concombre", "concombre" },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Avocat", "avocat" },
                    { new Guid("b0000000-0000-0000-0000-000000000028"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Pommes de terre", "pommesdeterre" },
                    { new Guid("b0000000-0000-0000-0000-000000000029"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Maïs", "mais" },
                    { new Guid("b0000000-0000-0000-0000-000000000031"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Crème", "creme" },
                    { new Guid("b0000000-0000-0000-0000-000000000032"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Yaourt nature", "yaourtnature" },
                    { new Guid("b0000000-0000-0000-0000-000000000033"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Feta", "feta" },
                    { new Guid("b0000000-0000-0000-0000-000000000034"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Mozzarella", "mozzarella" },
                    { new Guid("b0000000-0000-0000-0000-000000000035"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Parmesan", "parmesan" },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Huile d'olive", "huiledolive" },
                    { new Guid("b0000000-0000-0000-0000-000000000037"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Vinaigre balsamique", "vinaigrebalsamique" },
                    { new Guid("b0000000-0000-0000-0000-000000000038"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Sauce soja", "saucesoja" },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Citron", "citron" },
                    { new Guid("b0000000-0000-0000-0000-000000000040"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Miel", "miel" },
                    { new Guid("b0000000-0000-0000-0000-000000000041"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Cumin", "cumin" },
                    { new Guid("b0000000-0000-0000-0000-000000000042"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Paprika", "paprika" },
                    { new Guid("b0000000-0000-0000-0000-000000000043"), new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), "Curry", "curry" }
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
                    { new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), new DateTime(2026, 2, 22, 11, 35, 55, 36, DateTimeKind.Utc).AddTicks(2318), "Usertest", "usertest@mail.com", "4988d3e3-2a76-48df-8a8f-d7353ac9811eq6ubEYi/cX9Zqf0Y7vQk3tR1rwn58Z0OFeP9sOIOg3AvkY9QA/eHAH2RHNw8OA+lBLhIWqFpRuuaKPpFBYydBQ==", 1 },
                    { new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), new DateTime(2026, 2, 22, 11, 35, 55, 36, DateTimeKind.Utc).AddTicks(2118), "Kooz", "kooz@mail.com", "1b813899-603a-40cf-a635-c56ef6363ca52sQKF7IwePtw1OwhdieKiZNTz7nsk3R7x6lnvoBUCQeW0L7DRSMGnLd0TdjxiDCKwvSJgbHZqMnSaQH5nFsZDw==", 2 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "BasePortion", "CookTime", "CreatedAt", "CreatedByUserId", "Description", "ImageUrl", "IsPublic", "PrepTime", "Title" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), 2, 20, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Sauce tomate maison à l’ail et basilic. Simple et parfumé.", null, true, 10, "Pâtes tomate basilic" },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), 3, 25, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Haricots rouges, tomate, épices. Parfait en batch cooking.", null, true, 10, "Chili sin carne" },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), 2, 15, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Quinoa, concombre, tomate, feta, citron. Lunch frais.", null, true, 15, "Salade quinoa feta citron" },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), 1, 10, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Omelette moelleuse, champignons et épinards. Rapide.", null, true, 8, "Omelette champignons épinards" },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), 2, 20, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Poulet caramélisé soja-miel-citron, servi avec riz.", null, true, 10, "Poulet citron-miel & riz" },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), 4, 35, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Sauce bolognaise au bœuf haché, idéale avec pâtes.", null, true, 15, "Bolognaise maison" },
                    { new Guid("c0000000-0000-0000-0000-000000000007"), 4, 30, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Curry doux, lentilles et épinards, servi avec riz.", null, true, 10, "Curry de lentilles & épinards" },
                    { new Guid("c0000000-0000-0000-0000-000000000008"), 2, 0, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Wrap express : thon, avocat, tomate, citron.", null, true, 12, "Wrap thon avocat" },
                    { new Guid("c0000000-0000-0000-0000-000000000009"), 3, 0, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Pois chiches, concombre, tomate, cumin et citron.", null, true, 15, "Salade pois chiches" },
                    { new Guid("c0000000-0000-0000-0000-000000000010"), 2, 12, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Riz sauté rapide avec légumes et sauce soja.", null, true, 10, "Riz sauté aux œufs" },
                    { new Guid("c0000000-0000-0000-0000-000000000011"), 3, 20, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Poêlée simple : poulet, poivron, paprika, tomate.", null, true, 12, "Poulet paprika & poivrons" },
                    { new Guid("c0000000-0000-0000-0000-000000000012"), 2, 12, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Bowl équilibré : saumon, quinoa, avocat, crudités.", null, true, 15, "Bowl saumon quinoa avocat" },
                    { new Guid("c0000000-0000-0000-0000-000000000013"), 4, 45, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Gratin fondant, simple et familial.", null, true, 20, "Gratin pommes de terre mozzarella" },
                    { new Guid("c0000000-0000-0000-0000-000000000014"), 2, 18, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Sauce crémeuse champignons et parmesan.", null, true, 10, "Pâtes crème champignons parmesan" },
                    { new Guid("c0000000-0000-0000-0000-000000000015"), 4, 0, new DateTime(2026, 2, 21, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), "Taboulé frais : boulgour, tomate, concombre, citron.", null, true, 20, "Taboulé boulgour" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "BaseQuantity", "QuantityText", "Unit" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000001"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000001"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new Guid("c0000000-0000-0000-0000-000000000001"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000001"), 400m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new Guid("c0000000-0000-0000-0000-000000000001"), 20m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000035"), new Guid("c0000000-0000-0000-0000-000000000001"), 25m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000001"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000013"), new Guid("c0000000-0000-0000-0000-000000000002"), 400m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000002"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new Guid("c0000000-0000-0000-0000-000000000002"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000002"), 400m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new Guid("c0000000-0000-0000-0000-000000000002"), 20m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), new Guid("c0000000-0000-0000-0000-000000000002"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000002"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000041"), new Guid("c0000000-0000-0000-0000-000000000002"), 2m, null, 6 },
                    { new Guid("b0000000-0000-0000-0000-000000000042"), new Guid("c0000000-0000-0000-0000-000000000002"), 1m, null, 6 },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new Guid("c0000000-0000-0000-0000-000000000003"), 160m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000003"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000003"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000033"), new Guid("c0000000-0000-0000-0000-000000000003"), 120m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000003"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000003"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new Guid("c0000000-0000-0000-0000-000000000004"), 3m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000004"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000024"), new Guid("c0000000-0000-0000-0000-000000000004"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), new Guid("c0000000-0000-0000-0000-000000000004"), 150m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000004"), 5m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000005"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new Guid("c0000000-0000-0000-0000-000000000005"), 300m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000005"), 10m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000038"), new Guid("c0000000-0000-0000-0000-000000000005"), 30m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000005"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000040"), new Guid("c0000000-0000-0000-0000-000000000005"), 15m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000006"), 400m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new Guid("c0000000-0000-0000-0000-000000000006"), 500m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000006"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new Guid("c0000000-0000-0000-0000-000000000006"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000006"), 600m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), new Guid("c0000000-0000-0000-0000-000000000006"), 30m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000035"), new Guid("c0000000-0000-0000-0000-000000000006"), 40m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000006"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000007"), 300m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000015"), new Guid("c0000000-0000-0000-0000-000000000007"), 250m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000007"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new Guid("c0000000-0000-0000-0000-000000000007"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000007"), 400m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), new Guid("c0000000-0000-0000-0000-000000000007"), 150m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000007"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000043"), new Guid("c0000000-0000-0000-0000-000000000007"), 2m, null, 6 },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new Guid("c0000000-0000-0000-0000-000000000008"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new Guid("c0000000-0000-0000-0000-000000000008"), 160m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000008"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000008"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), new Guid("c0000000-0000-0000-0000-000000000008"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000008"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000014"), new Guid("c0000000-0000-0000-0000-000000000009"), 400m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000009"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000009"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000009"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000009"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000009"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000041"), new Guid("c0000000-0000-0000-0000-000000000009"), 1m, null, 6 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000010"), 250m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new Guid("c0000000-0000-0000-0000-000000000010"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000010"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000021"), new Guid("c0000000-0000-0000-0000-000000000010"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), new Guid("c0000000-0000-0000-0000-000000000010"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000010"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000038"), new Guid("c0000000-0000-0000-0000-000000000010"), 30m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new Guid("c0000000-0000-0000-0000-000000000011"), 450m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000011"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000011"), 300m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), new Guid("c0000000-0000-0000-0000-000000000011"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000011"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000042"), new Guid("c0000000-0000-0000-0000-000000000011"), 2m, null, 6 },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new Guid("c0000000-0000-0000-0000-000000000012"), 160m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new Guid("c0000000-0000-0000-0000-000000000012"), 300m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000012"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000012"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), new Guid("c0000000-0000-0000-0000-000000000012"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000012"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000012"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), new Guid("c0000000-0000-0000-0000-000000000013"), 2m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000028"), new Guid("c0000000-0000-0000-0000-000000000013"), 1000m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000031"), new Guid("c0000000-0000-0000-0000-000000000013"), 200m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000034"), new Guid("c0000000-0000-0000-0000-000000000013"), 200m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000014"), 220m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000014"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000024"), new Guid("c0000000-0000-0000-0000-000000000014"), 250m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000031"), new Guid("c0000000-0000-0000-0000-000000000014"), 150m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000035"), new Guid("c0000000-0000-0000-0000-000000000014"), 40m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000014"), 15m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new Guid("c0000000-0000-0000-0000-000000000015"), 250m, null, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000015"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000015"), 3m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000015"), 1m, null, 5 },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000015"), 30m, null, 3 },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000015"), 1m, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeSteps",
                columns: new[] { "Id", "RecipeId", "StepInstruction", "StepNumber" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000001"), "Émincer oignon et ail.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000001"), "Les faire revenir dans l’huile d’olive 3 minutes.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000003"), new Guid("c0000000-0000-0000-0000-000000000001"), "Ajouter tomates concassées + concentré, assaisonner.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000004"), new Guid("c0000000-0000-0000-0000-000000000001"), "Mijoter 12–15 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000005"), new Guid("c0000000-0000-0000-0000-000000000001"), "Cuire les pâtes, mélanger avec la sauce et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000006"), new Guid("c0000000-0000-0000-0000-000000000002"), "Émincer oignon et ail, couper le poivron en dés.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000007"), new Guid("c0000000-0000-0000-0000-000000000002"), "Faire revenir oignon/ail dans l’huile.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000008"), new Guid("c0000000-0000-0000-0000-000000000002"), "Ajouter le poivron puis tomates + épices.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000009"), new Guid("c0000000-0000-0000-0000-000000000002"), "Mijoter 10 minutes, ajouter les haricots rouges.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000010"), new Guid("c0000000-0000-0000-0000-000000000002"), "Mijoter encore 8 minutes et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000011"), new Guid("c0000000-0000-0000-0000-000000000003"), "Cuire le quinoa, puis le laisser tiédir.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000012"), new Guid("c0000000-0000-0000-0000-000000000003"), "Couper concombre et tomate en dés.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000013"), new Guid("c0000000-0000-0000-0000-000000000003"), "Émietter la feta.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000014"), new Guid("c0000000-0000-0000-0000-000000000003"), "Assaisonner avec citron + huile d’olive.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000015"), new Guid("c0000000-0000-0000-0000-000000000003"), "Mélanger, reposer 10 minutes et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000016"), new Guid("c0000000-0000-0000-0000-000000000004"), "Émincer oignon, couper champignons.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000017"), new Guid("c0000000-0000-0000-0000-000000000004"), "Faire revenir oignon + champignons.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000018"), new Guid("c0000000-0000-0000-0000-000000000004"), "Ajouter épinards 2 minutes.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000019"), new Guid("c0000000-0000-0000-0000-000000000004"), "Battre les œufs et verser sur la garniture.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000020"), new Guid("c0000000-0000-0000-0000-000000000004"), "Cuire à feu doux, plier et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000021"), new Guid("c0000000-0000-0000-0000-000000000005"), "Cuire le riz.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000022"), new Guid("c0000000-0000-0000-0000-000000000005"), "Saisir le poulet dans l’huile.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000023"), new Guid("c0000000-0000-0000-0000-000000000005"), "Ajouter soja + miel + citron.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000024"), new Guid("c0000000-0000-0000-0000-000000000005"), "Laisser réduire 4–5 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000025"), new Guid("c0000000-0000-0000-0000-000000000005"), "Servir sur le riz.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000026"), new Guid("c0000000-0000-0000-0000-000000000006"), "Faire revenir oignon et ail dans l’huile.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000027"), new Guid("c0000000-0000-0000-0000-000000000006"), "Ajouter le bœuf haché et le faire dorer.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000028"), new Guid("c0000000-0000-0000-0000-000000000006"), "Ajouter tomates + concentré, assaisonner.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000029"), new Guid("c0000000-0000-0000-0000-000000000006"), "Mijoter 25–30 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000030"), new Guid("c0000000-0000-0000-0000-000000000006"), "Cuire les pâtes et servir avec la sauce.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000031"), new Guid("c0000000-0000-0000-0000-000000000007"), "Faire revenir oignon et ail dans l’huile.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000032"), new Guid("c0000000-0000-0000-0000-000000000007"), "Ajouter curry et mélanger 30 secondes.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000033"), new Guid("c0000000-0000-0000-0000-000000000007"), "Ajouter lentilles + tomates, cuire 20 minutes.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000034"), new Guid("c0000000-0000-0000-0000-000000000007"), "Ajouter épinards 2–3 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000035"), new Guid("c0000000-0000-0000-0000-000000000007"), "Servir avec riz.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000036"), new Guid("c0000000-0000-0000-0000-000000000008"), "Égoutter le thon.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000037"), new Guid("c0000000-0000-0000-0000-000000000008"), "Écraser l’avocat avec le citron.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000038"), new Guid("c0000000-0000-0000-0000-000000000008"), "Couper tomate et concombre.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000039"), new Guid("c0000000-0000-0000-0000-000000000008"), "Garnir la tortilla et rouler.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000040"), new Guid("c0000000-0000-0000-0000-000000000008"), "Couper et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000041"), new Guid("c0000000-0000-0000-0000-000000000009"), "Rincer les pois chiches.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000042"), new Guid("c0000000-0000-0000-0000-000000000009"), "Couper tomate, concombre et oignon.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000043"), new Guid("c0000000-0000-0000-0000-000000000009"), "Assaisonner citron + huile + cumin.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000044"), new Guid("c0000000-0000-0000-0000-000000000009"), "Mélanger et reposer 10 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000045"), new Guid("c0000000-0000-0000-0000-000000000009"), "Servir frais.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000046"), new Guid("c0000000-0000-0000-0000-000000000010"), "Faire revenir les légumes dans l’huile.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000047"), new Guid("c0000000-0000-0000-0000-000000000010"), "Brouiller les œufs dans la poêle.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000048"), new Guid("c0000000-0000-0000-0000-000000000010"), "Ajouter le riz et mélanger.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000049"), new Guid("c0000000-0000-0000-0000-000000000010"), "Ajouter sauce soja et faire sauter 2–3 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000050"), new Guid("c0000000-0000-0000-0000-000000000010"), "Servir chaud.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000051"), new Guid("c0000000-0000-0000-0000-000000000011"), "Dorer le poulet dans l’huile.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000052"), new Guid("c0000000-0000-0000-0000-000000000011"), "Ajouter oignon puis poivrons.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000053"), new Guid("c0000000-0000-0000-0000-000000000011"), "Ajouter paprika + tomates concassées.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000054"), new Guid("c0000000-0000-0000-0000-000000000011"), "Mijoter 10–12 minutes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000055"), new Guid("c0000000-0000-0000-0000-000000000011"), "Rectifier l’assaisonnement et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000056"), new Guid("c0000000-0000-0000-0000-000000000012"), "Cuire le quinoa.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000057"), new Guid("c0000000-0000-0000-0000-000000000012"), "Cuire le saumon à la poêle.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000058"), new Guid("c0000000-0000-0000-0000-000000000012"), "Couper avocat, concombre et tomate.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000059"), new Guid("c0000000-0000-0000-0000-000000000012"), "Assaisonner citron + huile.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000060"), new Guid("c0000000-0000-0000-0000-000000000012"), "Composer les bols et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000061"), new Guid("c0000000-0000-0000-0000-000000000013"), "Préchauffer le four à 190°C.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000062"), new Guid("c0000000-0000-0000-0000-000000000013"), "Éplucher et trancher les pommes de terre.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000063"), new Guid("c0000000-0000-0000-0000-000000000013"), "Mettre dans un plat avec ail et crème.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000064"), new Guid("c0000000-0000-0000-0000-000000000013"), "Cuire 35 minutes couvert.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000065"), new Guid("c0000000-0000-0000-0000-000000000013"), "Ajouter mozzarella et gratiner 10 minutes.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000066"), new Guid("c0000000-0000-0000-0000-000000000014"), "Cuire les pâtes al dente.", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000067"), new Guid("c0000000-0000-0000-0000-000000000014"), "Faire revenir oignon + champignons.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000068"), new Guid("c0000000-0000-0000-0000-000000000014"), "Ajouter la crème et chauffer 2–3 minutes.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000069"), new Guid("c0000000-0000-0000-0000-000000000014"), "Ajouter le parmesan et mélanger.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000070"), new Guid("c0000000-0000-0000-0000-000000000014"), "Ajouter les pâtes, mélanger et servir.", 5 },
                    { new Guid("d0000000-0000-0000-0000-000000000071"), new Guid("c0000000-0000-0000-0000-000000000015"), "Préparer le boulgour (réhydratation/cuisson selon paquet).", 1 },
                    { new Guid("d0000000-0000-0000-0000-000000000072"), new Guid("c0000000-0000-0000-0000-000000000015"), "Couper tomates, concombre et oignon.", 2 },
                    { new Guid("d0000000-0000-0000-0000-000000000073"), new Guid("c0000000-0000-0000-0000-000000000015"), "Assaisonner citron + huile d’olive.", 3 },
                    { new Guid("d0000000-0000-0000-0000-000000000074"), new Guid("c0000000-0000-0000-0000-000000000015"), "Mélanger boulgour + légumes.", 4 },
                    { new Guid("d0000000-0000-0000-0000-000000000075"), new Guid("c0000000-0000-0000-0000-000000000015"), "Laisser 20–30 minutes au frais et servir.", 5 }
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
                name: "IX_PlanSlots_Date",
                table: "PlanSlots",
                column: "Date");

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
                name: "IX_ShoppingListItems_ShoppingListId_IngredientId_Unit",
                table: "ShoppingListItems",
                columns: new[] { "ShoppingListId", "IngredientId", "Unit" },
                unique: true);

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
