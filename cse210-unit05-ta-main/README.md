# Unit 05 Team Activity - Polymorphism

## Activity Instructions

For today's activity, please follow these instructions:

1.  Organize into small groups of 2-3 people. Circle around one laptop and designate one person to be the main typer for today.
    
2.  Begin by cloning this project template by clicking the `Use this template` button.

3. Clone the newly created repository to your laptop.
    
4. Open and run the project in VS Code. Run the main program by opening a terminal and typing `dotnet run`.

5. Open the `Program.cs` file and read through the `Main()`.

6. Open the `Vehicle.cs` file and read through it. Answer these questions:

   - Which methods are abstract? 
   - What does an abstract method mean?
   - What does that mean for a child class?


7. Open the `Car.cs` file and read through it. Notice how it implements the `Drive()` method of a Vehicle.


8. Create a new class to represent a Boat in `Boat.cs`. This class must inherit from the `Vehicle` class and should override the `Drive()` method. Then go to `Program.cs` and create an instance of a `Boat`. Call the `.Drive()` method of a `Boat` to make sure it works.

9. Create two more classes that inherit from the Vehicle class. Some ideas include Airplane, Motorcycle, Bicycle, Submarine, etc.


10. Now go back to `Program.cs` and create a new list of vehicles. Add at least one of each kind of vehicle to the list. Then loop through the list and call `.Drive()` on each one.

11. (Optional stretch): Add an abstract `Refuel()` method, and implement it differently per vehicle.

