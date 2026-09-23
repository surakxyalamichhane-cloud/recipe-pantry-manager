namespace RecipePantryManager.Models
{
    public abstract class FoodItem
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public FoodItem()
        {
            Name = "";
            Unit = "";
        }

        public virtual string GetDisplayInfo()
        {
            return Name + " - " + Quantity + " " + Unit;
        }
    }
}