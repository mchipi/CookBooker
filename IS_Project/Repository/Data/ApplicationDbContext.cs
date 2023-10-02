using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientInRecipe> IngredientInRecipes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
        public virtual DbSet<IngredientInShoppingList> IngredientInShoppingLists { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Recipe>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Ingredient>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingList>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Category>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<IngredientInRecipe>()
                .HasKey(z => new { z.RecipeId, z.IngredientId, });

            builder.Entity<IngredientInRecipe>()
                .HasOne(z => z.Recipe)
                .WithMany()
                .HasForeignKey(z => z.RecipeId);

            builder.Entity<IngredientInRecipe>()
                .HasOne(z => z.Ingredient)
                .WithMany()
                .HasForeignKey(z => z.IngredientId);

            builder.Entity<IngredientInShoppingList>()
                .HasKey(z => new { z.ShoppingListId, z.IngredientId, z.RecipeId });

            builder.Entity<IngredientInShoppingList>()
                .HasOne(z => z.Ingredient)
                .WithMany()
                .HasForeignKey(z => new { z.RecipeId, z.IngredientId, });

            builder.Entity<IngredientInShoppingList>()
                .HasOne(z => z.ShoppingList)
                .WithMany()
                .HasForeignKey(z => z.ShoppingListId);

            



        }
    }
}

