# Recipe & Pantry Manager

## Project Description

Recipe & Pantry Manager is a C# Windows Forms application designed to help users manage pantry items and saved recipes in one place.

The application allows users to keep track of available ingredients, quantities, units, and expiry dates. It also allows users to create and manage recipes, compare recipe requirements against current pantry stock, and identify which recipes can be cooked using the ingredients already available.

The purpose of the application is to make pantry management easier, reduce unnecessary food waste, and help users decide what meals they can prepare.

---

## Features

The application currently includes the following features:

- Add pantry items with name, quantity, unit, and optional expiry date
- Edit existing pantry items
- Delete pantry items
- Save pantry data using JSON files
- Load saved pantry data when the application starts
- Display warnings for expired or soon-to-expire pantry items
- Create recipes with a name, category, and multiple ingredients
- Save and load recipe data using JSON
- Edit saved recipes
- Delete saved recipes
- Search recipes by:
  - Recipe name
  - Category
  - Ingredient
- Check whether a recipe can be cooked using current pantry stock
- Display missing ingredients when a recipe cannot be cooked
- Mark a recipe as cooked
- Automatically deduct used ingredient quantities from the pantry
- Basic input validation and error handling

---

## Object-Oriented Programming Concepts

The project demonstrates the main object-oriented programming concepts covered in ITS203.

### Classes and Objects

The application uses several classes to represent real-world objects, including:

- `FoodItem`
- `PantryItem`
- `RecipeIngredient`
- `Recipe`
- `DataStorage`

Objects created from these classes are used throughout the application to represent pantry items, recipe ingredients, and saved recipes.

### Encapsulation

The `FoodItem` class uses private fields with public properties to control access to values such as name, quantity, and unit.

Validation is included in the properties so invalid quantity values are not stored.

### Inheritance

`PantryItem` and `RecipeIngredient` inherit from the `FoodItem` base class.

This allows both classes to reuse common properties such as:

- Name
- Quantity
- Unit

### Abstraction

`FoodItem` is defined as an abstract class.

It represents the common characteristics shared by different types of food-related objects without being directly created as an object itself.

### Polymorphism

The `GetDisplayInfo()` method is defined in the `FoodItem` base class and overridden by the child classes.

This allows `PantryItem` and `RecipeIngredient` to provide different versions of the same method.

### Exception Handling

The application uses `try-catch` blocks when loading and saving JSON files.

This allows the program to handle file-related errors without unexpectedly crashing.

---

## Data Storage

The application uses JSON file-based storage.

Two files are used:

- `pantry.json` — stores pantry items
- `recipes.json` — stores saved recipes

The application uses `System.Text.Json` to serialize and deserialize objects.

The data is automatically loaded when the application starts and saved whenever pantry or recipe information is changed.

---

## How to Run the Application

1. Open the project in Microsoft Visual Studio.
2. Make sure the required .NET desktop development tools are installed.
3. Open the `RecipePantryManager` solution.
4. Build the solution using:

   `Build > Build Solution`

5. Run the application using:

   `F5`

   or click the **Start** button in Visual Studio.

No external database is required.

---

## Basic Usage

### Managing Pantry Items

1. Enter the pantry item name.
2. Enter the quantity.
3. Select the measurement unit.
4. Optionally select an expiry date.
5. Click **Add Pantry Item**.

Existing pantry items can also be selected and edited or deleted.

### Creating a Recipe

1. Enter the recipe name.
2. Enter the category.
3. Enter an ingredient name, quantity, and unit.
4. Click **Add Ingredient**.
5. Repeat for additional ingredients.
6. Click **Save Recipe**.

### Checking Recipe Availability

Click **Check Recipes** to compare saved recipes against the current pantry.

The application displays whether each recipe:

- Can Cook
- Cannot Cook

If ingredients are missing, their names are displayed.

### Cooking a Recipe

1. Select a saved recipe.
2. Click **Cook**.
3. The application checks that enough ingredients are available.
4. Required quantities are deducted from the pantry automatically.

---

## Testing

The application was manually tested using several scenarios, including:

- Adding valid pantry items
- Entering invalid or incomplete pantry information
- Editing and deleting pantry items
- Closing and reopening the program to verify JSON persistence
- Creating recipes containing multiple ingredients
- Searching recipes by name, category, and ingredient
- Checking recipes with sufficient pantry stock
- Checking recipes with missing ingredients
- Cooking recipes and confirming pantry quantities are reduced
- Testing expired and soon-to-expire pantry items
- Restarting the program to confirm saved recipes remain available

---

## Project Development

Git and GitHub were used throughout development.

Development was completed incrementally using meaningful commits for different stages of the project, including:

- Initial project setup
- Pantry management
- JSON storage
- Recipe creation
- Recipe matching
- OOP improvements
- Expiry warnings
- Recipe cooking
- Recipe search, editing, and deletion
- User interface improvements

---

## References and Tools Used

The following resources and tools were used during development:

- Microsoft Visual Studio
- C#
- Windows Forms
- .NET
- System.Text.Json
- Git
- GitHub
- Microsoft Learn documentation
- ChatGPT by OpenAI — used as a study support tool for understanding C#, Windows Forms, debugging, object-oriented programming concepts, and development planning

The final code was tested and reviewed to ensure that the implemented features could be understood and explained during the oral presentation.