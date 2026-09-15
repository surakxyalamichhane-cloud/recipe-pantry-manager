using System.Collections.Generic;

namespace RecipePantryManager.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";

        public List<RecipeIngredient> Ingredients { get; set; }
            = new List<RecipeIngredient>();
    }
}