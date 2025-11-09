using System.Reflection;
using System.Runtime.CompilerServices;
using System.Timers;
public class Activity
{
    private string _description;
    private string _name;
    protected int _sessionLength;
    protected int _sessionStartLength;
    private int _count = 0;
    private List<string> _animationImages = new List<string>()
    {
         "|", "/", "-", @"\"
    };
    protected List<String> numbers = new List<String>
    {
        "4", "3", "2", "1"
    };
    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;

    }
    public void StartMessage()
    {
        Console.WriteLine($"Welcome to the {_name.ToLower()} activity.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.WriteLine("How long would you like your session to be (in seconds)?");
        _sessionLength = int.Parse(Console.ReadLine());
        _sessionStartLength = _sessionLength;
        Console.WriteLine("Get Ready...");
        Animation(3);
        Console.WriteLine();
        Console.WriteLine();
    }
    
    public void Animation(int count)
    {
        _count = 0;

        while (_count != count)
        {
            foreach (string image in _animationImages)
            {
                Console.Write(image);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }

            _count += 1;
        }
    }
    public void Timer()
    {
        foreach (string number in numbers)
        {
            Console.Write(number);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public string GetRandomFromList(List<string> prompts)
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        string prompt = prompts[index];
        return prompt;
    }
    public void EndMessage()
    {
        _sessionLength = _sessionStartLength;
        Console.WriteLine();
        Console.WriteLine("Well Done!");
        Animation(3);
        Console.WriteLine($"Congrats, you have completed {_sessionLength} seconds of the {_name} Activity.");
        Animation(3);
    }
    

}