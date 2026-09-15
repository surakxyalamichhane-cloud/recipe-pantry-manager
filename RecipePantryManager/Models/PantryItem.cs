using System;

namespace RecipePantryManager.Models
{
    public class PantryItem : FoodItem
    {
        public int Id { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}