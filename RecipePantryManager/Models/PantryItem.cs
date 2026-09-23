using System;

namespace RecipePantryManager.Models
{
    public class PantryItem : FoodItem
    {
        public int Id { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public override string GetDisplayInfo()
        {
            if (ExpiryDate.HasValue)
            {
                return Name + " - " + Quantity + " " + Unit +
                       " - Expiry: " +
                       ExpiryDate.Value.ToShortDateString();
            }

            return Name + " - " + Quantity + " " + Unit;
        }
    }
}