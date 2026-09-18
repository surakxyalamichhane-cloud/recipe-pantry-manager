using RecipePantryManager.Models;
using RecipePantryManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RecipePantryManager
{
    public partial class Form1 : Form
    {
        private BindingList<PantryItem> pantryItems = new BindingList<PantryItem>();

        private BindingList<RecipeIngredient> currentIngredients =
            new BindingList<RecipeIngredient>();

        private BindingList<Recipe> recipes =
            new BindingList<Recipe>();

        private DataStorage storage = new DataStorage();

        public Form1()
        {
            InitializeComponent();

            // Pantry units
            cmbUnit.Items.Add("kg");
            cmbUnit.Items.Add("g");
            cmbUnit.Items.Add("L");
            cmbUnit.Items.Add("ml");
            cmbUnit.Items.Add("pcs");

            // Load saved pantry items
            List<PantryItem> savedItems = storage.LoadPantry();

            pantryItems = new BindingList<PantryItem>(savedItems);

            dgvPantry.DataSource = pantryItems;

            // Recipe ingredient units
            cmbIngredientUnit.Items.Add("kg");
            cmbIngredientUnit.Items.Add("g");
            cmbIngredientUnit.Items.Add("L");
            cmbIngredientUnit.Items.Add("ml");
            cmbIngredientUnit.Items.Add("pcs");

            dgvIngredients.DataSource = currentIngredients;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter an item name.");
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }

            if (cmbUnit.SelectedItem == null)
            {
                MessageBox.Show("Please select a unit.");
                return;
            }

            PantryItem item = new PantryItem
            {
                Id = pantryItems.Count + 1,
                Name = txtName.Text.Trim(),
                Quantity = (double)numQuantity.Value,
                Unit = cmbUnit.SelectedItem.ToString(),
                ExpiryDate = dtpExpiry.Checked
                    ? (DateTime?)dtpExpiry.Value.Date
                    : null
            };

            pantryItems.Add(item);

            storage.SavePantry(pantryItems.ToList());

            ClearInputs();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (dgvPantry.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to edit.");
                return;
            }

            PantryItem selectedItem =
                (PantryItem)dgvPantry.CurrentRow.DataBoundItem;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter an item name.");
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }

            selectedItem.Name = txtName.Text.Trim();
            selectedItem.Quantity = (double)numQuantity.Value;

            if (cmbUnit.SelectedItem != null)
            {
                selectedItem.Unit = cmbUnit.SelectedItem.ToString();
            }

            selectedItem.ExpiryDate = dtpExpiry.Checked
                ? (DateTime?)dtpExpiry.Value.Date
                : null;

            dgvPantry.Refresh();

            storage.SavePantry(pantryItems.ToList());

            MessageBox.Show("Item updated successfully.");

            ClearInputs();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvPantry.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            PantryItem selectedItem =
                (PantryItem)dgvPantry.CurrentRow.DataBoundItem;

            pantryItems.Remove(selectedItem);

            storage.SavePantry(pantryItems.ToList());

            MessageBox.Show("Item deleted successfully.");
        }

        private void ClearInputs()
        {
            txtName.Clear();
            numQuantity.Value = 0;
            cmbUnit.SelectedIndex = -1;
            dtpExpiry.Checked = false;
        }

        // ----------------------------
        // Recipe functionality
        // ----------------------------

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text))
            {
                MessageBox.Show("Please enter an ingredient name.");
                return;
            }

            if (numIngredientQuantity.Value <= 0)
            {
                MessageBox.Show(
                    "Ingredient quantity must be greater than zero."
                );
                return;
            }

            if (cmbIngredientUnit.SelectedItem == null)
            {
                MessageBox.Show("Please select an ingredient unit.");
                return;
            }

            RecipeIngredient ingredient = new RecipeIngredient
            {
                Name = txtIngredientName.Text.Trim(),
                Quantity = (double)numIngredientQuantity.Value,
                Unit = cmbIngredientUnit.SelectedItem.ToString()
            };

            currentIngredients.Add(ingredient);

            ClearIngredientInputs();
        }

        private void btnSaveRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please enter a category.");
                return;
            }

            if (currentIngredients.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one ingredient."
                );
                return;
            }

            Recipe recipe = new Recipe
            {
                Id = recipes.Count + 1,
                Name = txtRecipeName.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Ingredients = currentIngredients.ToList()
            };

            recipes.Add(recipe);

            MessageBox.Show("Recipe saved successfully.");

            txtRecipeName.Clear();
            txtCategory.Clear();
            currentIngredients.Clear();
        }

        private void ClearIngredientInputs()
        {
            txtIngredientName.Clear();
            numIngredientQuantity.Value = 0;
            cmbIngredientUnit.SelectedIndex = -1;
        }

        private void btnCheckRecipes_Click(object sender, EventArgs e)
        {
            lstRecipeResults.Items.Clear();

            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes have been saved yet.");
                return;
            }

            foreach (Recipe recipe in recipes)
            {
                bool canCook = true;

                foreach (RecipeIngredient ingredient in recipe.Ingredients)
                {
                    PantryItem matchingItem = pantryItems.FirstOrDefault(item =>
                        item.Name.Equals(
                            ingredient.Name,
                            StringComparison.OrdinalIgnoreCase)
                        &&
                        item.Unit.Equals(
                            ingredient.Unit,
                            StringComparison.OrdinalIgnoreCase));

                    if (matchingItem == null ||
                        matchingItem.Quantity < ingredient.Quantity)
                    {
                        canCook = false;
                        break;
                    }
                }

                if (canCook)
                {
                    lstRecipeResults.Items.Add(
                        recipe.Name + " - Can Cook");
                }
                else
                {
                    lstRecipeResults.Items.Add(
                        recipe.Name + " - Cannot Cook");
                }
            }
        }

        // These methods were already connected in your form.
        // They can remain empty for now.

        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}