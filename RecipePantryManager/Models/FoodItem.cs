namespace RecipePantryManager.Models
{
    public abstract class FoodItem
    {
        private string name;
        private double quantity;
        private string unit;

        public string Name
        {
            get { return name; }
            set { name = value == null ? "" : value.Trim(); }
        }

        public double Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    quantity = 0;
                else
                    quantity = value;
            }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value == null ? "" : value.Trim(); }
        }

        public FoodItem()
        {
            name = "";
            unit = "";
            quantity = 0;
        }

        public virtual string GetDisplayInfo()
        {
            return Name + " - " + Quantity + " " + Unit;
        }
    }
}