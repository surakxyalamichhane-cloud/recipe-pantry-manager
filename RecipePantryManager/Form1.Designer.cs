namespace RecipePantryManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvPantry = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();

            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.numIngredientQuantity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbIngredientUnit = new System.Windows.Forms.ComboBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.btnSaveRecipe = new System.Windows.Forms.Button();
            this.btnCheckRecipes = new System.Windows.Forms.Button();
            this.lstRecipeResults = new System.Windows.Forms.ListBox();

            this.lstRecipes = new System.Windows.Forms.ListBox();
            this.btnCookRecipe = new System.Windows.Forms.Button();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblPantryTitle = new System.Windows.Forms.Label();
            this.lblRecipeTitle = new System.Windows.Forms.Label();
            this.lblSavedRecipes = new System.Windows.Forms.Label();
            this.lblRecipeResults = new System.Windows.Forms.Label();

            this.pnlPantry = new System.Windows.Forms.Panel();
            this.pnlRecipe = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPantry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIngredientQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();

            this.pnlPantry.SuspendLayout();
            this.pnlRecipe.SuspendLayout();
            this.SuspendLayout();

            // -------------------------------------------------
            // TITLE
            // -------------------------------------------------

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(28, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.Text = "Recipe & Pantry Manager";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font(
                "Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(31, 57);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(390, 15);
            this.lblSubtitle.Text =
                "Manage pantry stock, save recipes and check what you can cook.";

            // -------------------------------------------------
            // PANTRY PANEL
            // -------------------------------------------------

            this.pnlPantry.BackColor = System.Drawing.Color.White;
            this.pnlPantry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPantry.Location = new System.Drawing.Point(30, 95);
            this.pnlPantry.Name = "pnlPantry";
            this.pnlPantry.Size = new System.Drawing.Size(500, 625);

            this.lblPantryTitle.AutoSize = true;
            this.lblPantryTitle.Font = new System.Drawing.Font(
                "Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPantryTitle.Location = new System.Drawing.Point(20, 18);
            this.lblPantryTitle.Text = "Pantry Management";

            // Name
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 66);
            this.label1.Text = "Name:";

            this.txtName.Location = new System.Drawing.Point(120, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(340, 23);
            this.txtName.TextChanged +=
                new System.EventHandler(this.txtName_TextChanged);

            // Quantity
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 104);
            this.label2.Text = "Quantity:";

            this.numQuantity.DecimalPlaces = 2;
            this.numQuantity.Location = new System.Drawing.Point(120, 100);
            this.numQuantity.Maximum = new decimal(new int[] {
                10000, 0, 0, 0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(340, 23);

            // Unit
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 142);
            this.label3.Text = "Unit:";

            this.cmbUnit.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(120, 138);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(340, 23);

            // Expiry
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 180);
            this.label4.Text = "Expiry Date:";

            this.dtpExpiry.Location = new System.Drawing.Point(120, 176);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.ShowCheckBox = true;
            this.dtpExpiry.Size = new System.Drawing.Size(340, 23);

            // Add Item
            this.btnAddItem.Location = new System.Drawing.Point(24, 220);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(436, 36);
            this.btnAddItem.Text = "Add Pantry Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click +=
                new System.EventHandler(this.btnAddItem_Click);

            // Edit
            this.btnEditItem.Location = new System.Drawing.Point(24, 266);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(213, 34);
            this.btnEditItem.Text = "Edit Selected";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click +=
                new System.EventHandler(this.btnEditItem_Click);

            // Delete
            this.btnDeleteItem.Location = new System.Drawing.Point(247, 266);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(213, 34);
            this.btnDeleteItem.Text = "Delete Selected";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click +=
                new System.EventHandler(this.btnDeleteItem_Click);

            // Pantry heading
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(21, 326);
            this.label5.Text = "Pantry Items";

            // Pantry grid
            this.dgvPantry.AllowUserToAddRows = false;
            this.dgvPantry.AllowUserToDeleteRows = false;
            this.dgvPantry.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPantry.BackgroundColor = System.Drawing.Color.White;
            this.dgvPantry.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPantry.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPantry.Location = new System.Drawing.Point(24, 355);
            this.dgvPantry.Name = "dgvPantry";
            this.dgvPantry.ReadOnly = true;
            this.dgvPantry.RowHeadersWidth = 45;
            this.dgvPantry.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPantry.Size = new System.Drawing.Size(436, 235);

            // Add controls to pantry panel
            this.pnlPantry.Controls.Add(this.lblPantryTitle);
            this.pnlPantry.Controls.Add(this.label1);
            this.pnlPantry.Controls.Add(this.txtName);
            this.pnlPantry.Controls.Add(this.label2);
            this.pnlPantry.Controls.Add(this.numQuantity);
            this.pnlPantry.Controls.Add(this.label3);
            this.pnlPantry.Controls.Add(this.cmbUnit);
            this.pnlPantry.Controls.Add(this.label4);
            this.pnlPantry.Controls.Add(this.dtpExpiry);
            this.pnlPantry.Controls.Add(this.btnAddItem);
            this.pnlPantry.Controls.Add(this.btnEditItem);
            this.pnlPantry.Controls.Add(this.btnDeleteItem);
            this.pnlPantry.Controls.Add(this.label5);
            this.pnlPantry.Controls.Add(this.dgvPantry);

            // -------------------------------------------------
            // RECIPE PANEL
            // -------------------------------------------------

            this.pnlRecipe.BackColor = System.Drawing.Color.White;
            this.pnlRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecipe.Location = new System.Drawing.Point(550, 95);
            this.pnlRecipe.Name = "pnlRecipe";
            this.pnlRecipe.Size = new System.Drawing.Size(550, 625);

            this.lblRecipeTitle.AutoSize = true;
            this.lblRecipeTitle.Font = new System.Drawing.Font(
                "Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRecipeTitle.Location = new System.Drawing.Point(20, 18);
            this.lblRecipeTitle.Text = "Recipe Management";

            // Recipe Name
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 66);
            this.label6.Text = "Recipe Name:";

            this.txtRecipeName.Location = new System.Drawing.Point(130, 62);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(380, 23);

            // Category
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 104);
            this.label7.Text = "Category:";

            this.txtCategory.Location = new System.Drawing.Point(130, 100);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(380, 23);

            // Ingredient
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 142);
            this.label8.Text = "Ingredient:";

            this.txtIngredientName.Location =
                new System.Drawing.Point(130, 138);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(380, 23);

            // Ingredient Quantity
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 180);
            this.label9.Text = "Quantity:";

            this.numIngredientQuantity.DecimalPlaces = 2;
            this.numIngredientQuantity.Location =
                new System.Drawing.Point(130, 176);
            this.numIngredientQuantity.Maximum =
                new decimal(new int[] { 10000, 0, 0, 0 });
            this.numIngredientQuantity.Name =
                "numIngredientQuantity";
            this.numIngredientQuantity.Size =
                new System.Drawing.Size(175, 23);

            // Ingredient Unit
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 180);
            this.label10.Text = "Unit:";

            this.cmbIngredientUnit.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngredientUnit.FormattingEnabled = true;
            this.cmbIngredientUnit.Location =
                new System.Drawing.Point(360, 176);
            this.cmbIngredientUnit.Name = "cmbIngredientUnit";
            this.cmbIngredientUnit.Size =
                new System.Drawing.Size(150, 23);

            // Add Ingredient
            this.btnAddIngredient.Location =
                new System.Drawing.Point(24, 216);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size =
                new System.Drawing.Size(486, 34);
            this.btnAddIngredient.Text = "Add Ingredient";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click +=
                new System.EventHandler(this.btnAddIngredient_Click);

            // Ingredient label
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location =
                new System.Drawing.Point(21, 266);
            this.label11.Text = "Ingredients";

            // Ingredients grid
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            this.dgvIngredients.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredients.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvIngredients.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Location =
                new System.Drawing.Point(24, 295);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.ReadOnly = true;
            this.dgvIngredients.RowHeadersWidth = 45;
            this.dgvIngredients.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size =
                new System.Drawing.Size(486, 125);

            // Save Recipe
            this.btnSaveRecipe.Location =
                new System.Drawing.Point(24, 430);
            this.btnSaveRecipe.Name = "btnSaveRecipe";
            this.btnSaveRecipe.Size =
                new System.Drawing.Size(235, 34);
            this.btnSaveRecipe.Text = "Save Recipe";
            this.btnSaveRecipe.UseVisualStyleBackColor = true;
            this.btnSaveRecipe.Click +=
                new System.EventHandler(this.btnSaveRecipe_Click);

            // Check Recipes
            this.btnCheckRecipes.Location =
                new System.Drawing.Point(275, 430);
            this.btnCheckRecipes.Name = "btnCheckRecipes";
            this.btnCheckRecipes.Size =
                new System.Drawing.Size(235, 34);
            this.btnCheckRecipes.Text = "Check Recipes";
            this.btnCheckRecipes.UseVisualStyleBackColor = true;
            this.btnCheckRecipes.Click +=
                new System.EventHandler(this.btnCheckRecipes_Click);

            // Saved Recipes label
            this.lblSavedRecipes.AutoSize = true;
            this.lblSavedRecipes.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSavedRecipes.Location =
                new System.Drawing.Point(21, 481);
            this.lblSavedRecipes.Text = "Saved Recipes";

            // Saved Recipes
            this.lstRecipes.FormattingEnabled = true;
            this.lstRecipes.Location =
                new System.Drawing.Point(24, 506);
            this.lstRecipes.Name = "lstRecipes";
            this.lstRecipes.Size =
                new System.Drawing.Size(235, 69);

            // Cook Recipe
            this.btnCookRecipe.Location =
                new System.Drawing.Point(24, 582);
            this.btnCookRecipe.Name = "btnCookRecipe";
            this.btnCookRecipe.Size =
                new System.Drawing.Size(235, 30);
            this.btnCookRecipe.Text = "Cook Selected Recipe";
            this.btnCookRecipe.UseVisualStyleBackColor = true;
            this.btnCookRecipe.Click +=
                new System.EventHandler(this.btnCookRecipe_Click);

            // Recipe Results label
            this.lblRecipeResults.AutoSize = true;
            this.lblRecipeResults.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecipeResults.Location =
                new System.Drawing.Point(272, 481);
            this.lblRecipeResults.Text = "Recipe Availability";

            // Recipe Results
            this.lstRecipeResults.FormattingEnabled = true;
            this.lstRecipeResults.Location =
                new System.Drawing.Point(275, 506);
            this.lstRecipeResults.Name = "lstRecipeResults";
            this.lstRecipeResults.Size =
                new System.Drawing.Size(235, 108);

            // Add controls to recipe panel
            this.pnlRecipe.Controls.Add(this.lblRecipeTitle);
            this.pnlRecipe.Controls.Add(this.label6);
            this.pnlRecipe.Controls.Add(this.txtRecipeName);
            this.pnlRecipe.Controls.Add(this.label7);
            this.pnlRecipe.Controls.Add(this.txtCategory);
            this.pnlRecipe.Controls.Add(this.label8);
            this.pnlRecipe.Controls.Add(this.txtIngredientName);
            this.pnlRecipe.Controls.Add(this.label9);
            this.pnlRecipe.Controls.Add(this.numIngredientQuantity);
            this.pnlRecipe.Controls.Add(this.label10);
            this.pnlRecipe.Controls.Add(this.cmbIngredientUnit);
            this.pnlRecipe.Controls.Add(this.btnAddIngredient);
            this.pnlRecipe.Controls.Add(this.label11);
            this.pnlRecipe.Controls.Add(this.dgvIngredients);
            this.pnlRecipe.Controls.Add(this.btnSaveRecipe);
            this.pnlRecipe.Controls.Add(this.btnCheckRecipes);
            this.pnlRecipe.Controls.Add(this.lblSavedRecipes);
            this.pnlRecipe.Controls.Add(this.lstRecipes);
            this.pnlRecipe.Controls.Add(this.btnCookRecipe);
            this.pnlRecipe.Controls.Add(this.lblRecipeResults);
            this.pnlRecipe.Controls.Add(this.lstRecipeResults);

            // -------------------------------------------------
            // FORM
            // -------------------------------------------------

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);

            this.ClientSize =
                new System.Drawing.Size(1135, 755);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.pnlPantry);
            this.Controls.Add(this.pnlRecipe);

            this.Font = new System.Drawing.Font(
                "Segoe UI", 9F);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe & Pantry Manager";

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPantry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIngredientQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();

            this.pnlPantry.ResumeLayout(false);
            this.pnlPantry.PerformLayout();

            this.pnlRecipe.ResumeLayout(false);
            this.pnlRecipe.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvPantry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnDeleteItem;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.NumericUpDown numIngredientQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbIngredientUnit;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.Button btnSaveRecipe;
        private System.Windows.Forms.Button btnCheckRecipes;
        private System.Windows.Forms.ListBox lstRecipeResults;

        private System.Windows.Forms.ListBox lstRecipes;
        private System.Windows.Forms.Button btnCookRecipe;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblPantryTitle;
        private System.Windows.Forms.Label lblRecipeTitle;
        private System.Windows.Forms.Label lblSavedRecipes;
        private System.Windows.Forms.Label lblRecipeResults;

        private System.Windows.Forms.Panel pnlPantry;
        private System.Windows.Forms.Panel pnlRecipe;
    }
}