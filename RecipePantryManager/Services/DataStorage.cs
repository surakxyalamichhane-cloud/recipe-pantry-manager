using RecipePantryManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace RecipePantryManager.Services
{
    public class DataStorage
    {
        private string pantryFile = "pantry.json";

        public List<PantryItem> LoadPantry()
        {
            try
            {
                if (!File.Exists(pantryFile))
                {
                    return new List<PantryItem>();
                }

                string json = File.ReadAllText(pantryFile);

                List<PantryItem> items =
                    JsonSerializer.Deserialize<List<PantryItem>>(json);

                return items ?? new List<PantryItem>();
            }
            catch
            {
                MessageBox.Show("Unable to load pantry data.");
                return new List<PantryItem>();
            }
        }

        public void SavePantry(List<PantryItem> items)
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    items,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(pantryFile, json);
            }
            catch
            {
                MessageBox.Show("Unable to save pantry data.");
            }
        }
    }
}