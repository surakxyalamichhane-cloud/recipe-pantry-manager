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
        private string recipeFile = "recipes.json";

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

        public List<Recipe> LoadRecipes()
        {
            try
            {
                if (!File.Exists(recipeFile))
                {
                    return new List<Recipe>();
                }

                string json = File.ReadAllText(recipeFile);

                List<Recipe> savedRecipes =
                    JsonSerializer.Deserialize<List<Recipe>>(json);

                return savedRecipes ?? new List<Recipe>();
            }
            catch
            {
                MessageBox.Show("Unable to load recipe data.");
                return new List<Recipe>();
            }
        }

        public void SaveRecipes(List<Recipe> recipes)
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    recipes,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(recipeFile, json);
            }
            catch
            {
                MessageBox.Show("Unable to save recipe data.");
            }
        }
    }
}