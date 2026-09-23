namespace RecipePantryManager.Models
{
    public class RecipeIngredient : FoodItem
    {
        public override string GetDisplayInfo()
        {
            return Name + " - Required: " +
                   Quantity + " " + Unit;
        }
    }
}