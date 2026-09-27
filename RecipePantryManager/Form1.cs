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
        // Lists used to store pantry and recipe data
        private BindingList<PantryItem> pantryItems =
            new BindingList<PantryItem>();

        private BindingList<RecipeIngredient> currentIngredients =
            new BindingList<RecipeIngredient>();

        private BindingList<Recipe> recipes =
            new BindingList<Recipe>();

        private DataStorage storage = new DataStorage();

        // Used for recipe edit and filtered recipe display
        private int editingRecipeIndex = -1;

        private List<Recipe> displayedRecipes =
            new List<Recipe>();

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
            List<PantryItem> savedItems =
                storage.LoadPantry();

            pantryItems =
                new BindingList<PantryItem>(savedItems);

            dgvPantry.DataSource = pantryItems;

            // Load saved recipes
            List<Recipe> savedRecipes =
                storage.LoadRecipes();

            recipes =
                new BindingList<Recipe>(savedRecipes);

            // Recipe ingredient units
            cmbIngredientUnit.Items.Add("kg");
            cmbIngredientUnit.Items.Add("g");
            cmbIngredientUnit.Items.Add("L");
            cmbIngredientUnit.Items.Add("ml");
            cmbIngredientUnit.Items.Add("pcs");

            dgvIngredients.DataSource =
                currentIngredients;

            // Show saved recipes
            RefreshRecipeList();

            // Check expiry when program opens
            CheckExpiryWarnings();
        }

        // -------------------------------------------------
        // PANTRY
        // -------------------------------------------------

        private void btnAddItem_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Please enter an item name.");
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show(
                    "Quantity must be greater than zero.");
                return;
            }

            if (cmbUnit.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a unit.");
                return;
            }

            PantryItem item = new PantryItem
            {
                Id = pantryItems.Count + 1,
                Name = txtName.Text.Trim(),
                Quantity =
                    (double)numQuantity.Value,
                Unit =
                    cmbUnit.SelectedItem.ToString(),
                ExpiryDate = dtpExpiry.Checked
                    ? (DateTime?)dtpExpiry.Value.Date
                    : null
            };

            pantryItems.Add(item);

            storage.SavePantry(
                pantryItems.ToList());

            ClearInputs();
        }

        private void btnEditItem_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPantry.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an item to edit.");
                return;
            }

            PantryItem selectedItem =
                (PantryItem)
                dgvPantry.CurrentRow.DataBoundItem;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Please enter an item name.");
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show(
                    "Quantity must be greater than zero.");
                return;
            }

            selectedItem.Name =
                txtName.Text.Trim();

            selectedItem.Quantity =
                (double)numQuantity.Value;

            if (cmbUnit.SelectedItem != null)
            {
                selectedItem.Unit =
                    cmbUnit.SelectedItem.ToString();
            }

            selectedItem.ExpiryDate =
                dtpExpiry.Checked
                    ? (DateTime?)dtpExpiry.Value.Date
                    : null;

            dgvPantry.Refresh();

            storage.SavePantry(
                pantryItems.ToList());

            MessageBox.Show(
                "Item updated successfully.");

            ClearInputs();
        }

        private void btnDeleteItem_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPantry.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an item to delete.");
                return;
            }

            PantryItem selectedItem =
                (PantryItem)
                dgvPantry.CurrentRow.DataBoundItem;

            pantryItems.Remove(selectedItem);

            storage.SavePantry(
                pantryItems.ToList());

            MessageBox.Show(
                "Item deleted successfully.");
        }

        private void ClearInputs()
        {
            txtName.Clear();
            numQuantity.Value = 0;
            cmbUnit.SelectedIndex = -1;
            dtpExpiry.Checked = false;
        }

        // -------------------------------------------------
        // EXPIRY WARNINGS
        // -------------------------------------------------

        private void CheckExpiryWarnings()
        {
            foreach (PantryItem item in pantryItems)
            {
                if (item.ExpiryDate.HasValue)
                {
                    int daysLeft =
                        (item.ExpiryDate.Value.Date -
                         DateTime.Today).Days;

                    if (daysLeft < 0)
                    {
                        MessageBox.Show(
                            item.Name + " has expired.",
                            "Expiry Warning");
                    }
                    else if (daysLeft <= 3)
                    {
                        MessageBox.Show(
                            item.Name +
                            " will expire in " +
                            daysLeft +
                            " day(s).",
                            "Expiry Warning");
                    }
                }
            }
        }

        // -------------------------------------------------
        // RECIPE INGREDIENTS
        // -------------------------------------------------

        private void btnAddIngredient_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtIngredientName.Text))
            {
                MessageBox.Show(
                    "Please enter an ingredient name.");
                return;
            }

            if (numIngredientQuantity.Value <= 0)
            {
                MessageBox.Show(
                    "Ingredient quantity must be greater than zero.");
                return;
            }

            if (cmbIngredientUnit.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select an ingredient unit.");
                return;
            }

            RecipeIngredient ingredient =
                new RecipeIngredient
                {
                    Name =
                        txtIngredientName.Text.Trim(),

                    Quantity =
                        (double)
                        numIngredientQuantity.Value,

                    Unit =
                        cmbIngredientUnit
                        .SelectedItem
                        .ToString()
                };

            currentIngredients.Add(ingredient);

            ClearIngredientInputs();
        }

        private void ClearIngredientInputs()
        {
            txtIngredientName.Clear();
            numIngredientQuantity.Value = 0;
            cmbIngredientUnit.SelectedIndex = -1;
        }

        // -------------------------------------------------
        // RECIPE LIST
        // -------------------------------------------------

        private void RefreshRecipeList(
            IEnumerable<Recipe> source = null)
        {
            lstRecipes.Items.Clear();

            if (source == null)
            {
                displayedRecipes =
                    recipes.ToList();
            }
            else
            {
                displayedRecipes =
                    source.ToList();
            }

            foreach (Recipe recipe in displayedRecipes)
            {
                lstRecipes.Items.Add(
                    recipe.Name);
            }
        }

        // -------------------------------------------------
        // SAVE / UPDATE RECIPE
        // -------------------------------------------------

        private void btnSaveRecipe_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtRecipeName.Text))
            {
                MessageBox.Show(
                    "Please enter a recipe name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtCategory.Text))
            {
                MessageBox.Show(
                    "Please enter a category.");
                return;
            }

            if (currentIngredients.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one ingredient.");
                return;
            }

            if (editingRecipeIndex >= 0)
            {
                Recipe recipeToUpdate =
                    recipes[editingRecipeIndex];

                recipeToUpdate.Name =
                    txtRecipeName.Text.Trim();

                recipeToUpdate.Category =
                    txtCategory.Text.Trim();

                recipeToUpdate.Ingredients =
                    currentIngredients.ToList();

                editingRecipeIndex = -1;

                btnSaveRecipe.Text =
                    "Save Recipe";

                MessageBox.Show(
                    "Recipe updated successfully.");
            }
            else
            {
                Recipe recipe = new Recipe
                {
                    Id = recipes.Count + 1,

                    Name =
                        txtRecipeName.Text.Trim(),

                    Category =
                        txtCategory.Text.Trim(),

                    Ingredients =
                        currentIngredients.ToList()
                };

                recipes.Add(recipe);

                MessageBox.Show(
                    "Recipe saved successfully.");
            }

            storage.SaveRecipes(
                recipes.ToList());

            RefreshRecipeList();

            txtRecipeName.Clear();
            txtCategory.Clear();
            currentIngredients.Clear();
        }

        // -------------------------------------------------
        // EDIT RECIPE
        // -------------------------------------------------

        private void btnEditRecipe_Click(
            object sender,
            EventArgs e)
        {
            if (lstRecipes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a recipe to edit.");
                return;
            }

            Recipe selectedRecipe =
                displayedRecipes[
                    lstRecipes.SelectedIndex];

            editingRecipeIndex =
                recipes.IndexOf(selectedRecipe);

            txtRecipeName.Text =
                selectedRecipe.Name;

            txtCategory.Text =
                selectedRecipe.Category;

            currentIngredients.Clear();

            foreach (
                RecipeIngredient ingredient
                in selectedRecipe.Ingredients)
            {
                currentIngredients.Add(
                    new RecipeIngredient
                    {
                        Name =
                            ingredient.Name,

                        Quantity =
                            ingredient.Quantity,

                        Unit =
                            ingredient.Unit
                    });
            }

            btnSaveRecipe.Text =
                "Update Recipe";
        }

        // -------------------------------------------------
        // DELETE RECIPE
        // -------------------------------------------------

        private void btnDeleteRecipe_Click(
            object sender,
            EventArgs e)
        {
            if (lstRecipes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a recipe to delete.");
                return;
            }

            Recipe selectedRecipe =
                displayedRecipes[
                    lstRecipes.SelectedIndex];

            DialogResult result =
                MessageBox.Show(
                    "Delete " +
                    selectedRecipe.Name +
                    "?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

            if (result ==
                DialogResult.Yes)
            {
                recipes.Remove(
                    selectedRecipe);

                storage.SaveRecipes(
                    recipes.ToList());

                RefreshRecipeList();

                MessageBox.Show(
                    "Recipe deleted successfully.");
            }
        }

        // -------------------------------------------------
        // SEARCH RECIPES
        // -------------------------------------------------

        private void btnSearchRecipes_Click(
            object sender,
            EventArgs e)
        {
            string search =
                txtRecipeSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                RefreshRecipeList();
                return;
            }

            List<Recipe> results =
                recipes.Where(recipe =>
                    recipe.Name.IndexOf(
                        search,
                        StringComparison.OrdinalIgnoreCase)
                    >= 0
                    ||
                    recipe.Category.IndexOf(
                        search,
                        StringComparison.OrdinalIgnoreCase)
                    >= 0
                    ||
                    recipe.Ingredients.Any(
                        ingredient =>
                            ingredient.Name.IndexOf(
                                search,
                                StringComparison.OrdinalIgnoreCase)
                            >= 0)
                ).ToList();

            RefreshRecipeList(results);

            if (results.Count == 0)
            {
                MessageBox.Show(
                    "No matching recipes found.");
            }
        }

        private void btnClearSearch_Click(
            object sender,
            EventArgs e)
        {
            txtRecipeSearch.Clear();

            RefreshRecipeList();
        }

        // -------------------------------------------------
        // CHECK WHICH RECIPES CAN BE COOKED
        // -------------------------------------------------

        private void btnCheckRecipes_Click(
            object sender,
            EventArgs e)
        {
            lstRecipeResults.Items.Clear();

            if (recipes.Count == 0)
            {
                MessageBox.Show(
                    "No recipes have been saved yet.");
                return;
            }

            foreach (Recipe recipe in recipes)
            {
                List<string> missingIngredients =
                    new List<string>();

                foreach (
                    RecipeIngredient ingredient
                    in recipe.Ingredients)
                {
                    PantryItem matchingItem =
                        pantryItems.FirstOrDefault(
                            item =>
                                item.Name.Equals(
                                    ingredient.Name,
                                    StringComparison
                                        .OrdinalIgnoreCase)
                                &&
                                item.Unit.Equals(
                                    ingredient.Unit,
                                    StringComparison
                                        .OrdinalIgnoreCase));

                    if (matchingItem == null)
                    {
                        missingIngredients.Add(
                            ingredient.Name);
                    }
                    else if (
                        matchingItem.Quantity <
                        ingredient.Quantity)
                    {
                        missingIngredients.Add(
                            ingredient.Name);
                    }
                }

                if (missingIngredients.Count == 0)
                {
                    lstRecipeResults.Items.Add(
                        recipe.Name +
                        " - Can Cook");
                }
                else
                {
                    lstRecipeResults.Items.Add(
                        recipe.Name +
                        " - Cannot Cook - Missing: " +
                        string.Join(
                            ", ",
                            missingIngredients));
                }
            }
        }

        // -------------------------------------------------
        // COOK RECIPE
        // -------------------------------------------------

        private void btnCookRecipe_Click(
            object sender,
            EventArgs e)
        {
            if (lstRecipes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a recipe.");
                return;
            }

            Recipe selectedRecipe =
                displayedRecipes[
                    lstRecipes.SelectedIndex];

            // Check that all required ingredients exist
            foreach (
                RecipeIngredient ingredient
                in selectedRecipe.Ingredients)
            {
                PantryItem matchingItem =
                    pantryItems.FirstOrDefault(
                        item =>
                            item.Name.Equals(
                                ingredient.Name,
                                StringComparison
                                    .OrdinalIgnoreCase)
                            &&
                            item.Unit.Equals(
                                ingredient.Unit,
                                StringComparison
                                    .OrdinalIgnoreCase));

                if (matchingItem == null ||
                    matchingItem.Quantity <
                    ingredient.Quantity)
                {
                    MessageBox.Show(
                        "Not enough ingredients to cook this recipe.");
                    return;
                }
            }

            // Deduct pantry quantities
            foreach (
                RecipeIngredient ingredient
                in selectedRecipe.Ingredients)
            {
                PantryItem matchingItem =
                    pantryItems.First(
                        item =>
                            item.Name.Equals(
                                ingredient.Name,
                                StringComparison
                                    .OrdinalIgnoreCase)
                            &&
                            item.Unit.Equals(
                                ingredient.Unit,
                                StringComparison
                                    .OrdinalIgnoreCase));

                matchingItem.Quantity -=
                    ingredient.Quantity;
            }

            dgvPantry.Refresh();

            storage.SavePantry(
                pantryItems.ToList());

            MessageBox.Show(
                "Recipe cooked successfully. Pantry quantities have been updated."
            );
        }

        // -------------------------------------------------
        // UNUSED DESIGNER EVENTS
        // -------------------------------------------------

        private void txtName_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void label11_Click(
            object sender,
            EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}