using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientInShoppingLists_Ingredients_IngredientId",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientInShoppingLists",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_IngredientInShoppingLists_IngredientId",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "IngredientInShoppingLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "IngredientInRecipes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "IngredientInRecipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientInShoppingLists",
                table: "IngredientInShoppingLists",
                columns: new[] { "ShoppingListId", "IngredientId", "RecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientInShoppingLists_RecipeId_IngredientId",
                table: "IngredientInShoppingLists",
                columns: new[] { "RecipeId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientInShoppingLists_IngredientInRecipes_RecipeId_IngredientId",
                table: "IngredientInShoppingLists",
                columns: new[] { "RecipeId", "IngredientId" },
                principalTable: "IngredientInRecipes",
                principalColumns: new[] { "RecipeId", "IngredientId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientInShoppingLists_IngredientInRecipes_RecipeId_IngredientId",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientInShoppingLists",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_IngredientInShoppingLists_RecipeId_IngredientId",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "IngredientInShoppingLists");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "IngredientInRecipes");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "IngredientInRecipes");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Ingredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientInShoppingLists",
                table: "IngredientInShoppingLists",
                columns: new[] { "ShoppingListId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientInShoppingLists_IngredientId",
                table: "IngredientInShoppingLists",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientInShoppingLists_Ingredients_IngredientId",
                table: "IngredientInShoppingLists",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
