public class Reflection : Activity
{
    private string userInput;
    private List<string> _prompts = new List<string>
    {
        "Think of a time when someone appreciated something you did for them.",
        "Think of a time when you stood up for someone.",
        "Think of a time when you accomplished something you are proud of.",
        "Think of a time you sacrificed for someone else.",
        "Think about what brings you must joy in life, and perhaps what you have done to fight for that."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this moment so great?",
        "What did this make you want to do?",
        "What does this show about your character?",
        "What do you think inspired you to do this?",
        "How have you seen those around you help you accomplish or do this thing?"
    };
    public Reflection() : base("Reflection", "This activity will ask that you reminisce on times you were strong and proud of yourself. This will help you build confidence and empower you in your life.")
    {
        StartMessage();

        Console.WriteLine($"---{GetRandomFromList(_prompts)}---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        userInput = Console.ReadLine();
        while (userInput != "")
        {
            Console.WriteLine("Please press enter when ready to move on.");
        }

        Console.WriteLine("Now please ponder the following questions as you consider this experience:");
        Console.Write("You may begin in:");
        Timer();
        Console.WriteLine();
        while (_sessionLength > 0)
        {
            Console.Write($" > {GetRandomFromList(_questions)}");
            Animation(10);
            Console.WriteLine();
            
            _sessionLength -= 10;
        }
        EndMessage();
    }
    
}