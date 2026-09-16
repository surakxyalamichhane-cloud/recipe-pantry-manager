using RecipePantryManager.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RecipePantryManager
{
    public partial class Form1 : Form
    {
        private BindingList<PantryItem> pantryItems = new BindingList<PantryItem>();

        public Form1()
        {
            InitializeComponent();

            cmbUnit.Items.Add("kg");
            cmbUnit.Items.Add("g");
            cmbUnit.Items.Add("L");
            cmbUnit.Items.Add("ml");
            cmbUnit.Items.Add("pcs");

            dgvPantry.DataSource = pantryItems;
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
                ExpiryDate = dtpExpiry.Checked ? (DateTime?)dtpExpiry.Value.Date : null
            };

            pantryItems.Add(item);

            ClearInputs();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            numQuantity.Value = 0;
            cmbUnit.SelectedIndex = -1;
            dtpExpiry.Checked = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}