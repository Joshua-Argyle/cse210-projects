# Unit 04 Team Activity - Inheritance

## Activity Instructions

For today's activity, please follow these instructions:

1.  Organize into small groups of 2-3 people. Circle around one laptop and designate one person to be the main typer for today.
    
2.  Begin by cloning this project template by clicking the `Use this template` button.

3. Clone the newly created repository to your laptop.
    
4. Open and run the project in VS Code. Run the main program by opening a terminal and typing `dotnet run`.

5. Open the `Program.cs` file and read through the `Main()` and `CreateProducts()` functions. Discuss with your group how this program works. Answer the following questions:

   - Do you notice anything you haven't seen before?
   - What type of object is stored in the products list? 
   - What data type is used to represent price?


6. Open the `Product.cs` file and read through the `Product` class. Then open and read the `Book.cs` and `Electronics.cs` files. **Discuss with your group how `Book` and `Electronics` inherit from `Product`**.

   - What do you notice about the `GetInfo()` method?
   - What does the `virtual` keyword do?
   - What does the `override` keyword do?

7. Create a new class to represent a new category of your choice. This class must inherit from the `Product` class and should include at least 2 attributes not contained in the `Product` class. Make sure to call the `base` constructor from your new class and to override the `GetInfo()` method to display the appropriate information for your new category. Some ideas for a new category are Clothing, Household, Food, Video Games, etc.

8. Add at least 2 new products in the `Program.cs` file using your new category.

9. Run the program and make sure you can search for and display your new products.
