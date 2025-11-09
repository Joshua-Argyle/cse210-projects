
using System.Timers;

public class Listening : Activity
{
    private bool _timeUp = false;
    protected int listCount;
    private System.Timers.Timer _timer;
    private List<string> _prompts = new List<string>
    {
        "What are some of your strengths?",
        "What are some of your talents?",
        "How have you invited the holy ghost into your life this week?",
        "What are some of your best experiences with your mom?",
        "What are some of your best experiences with your dad?",
        "What are some ways you grown this week?",
        "Favorite heroes from movies, history, or books... GO!"
    };
    
    public Listening() : base("Listening", "This activity will help you reflect on positive things happening in your life by listing many things on a certain topic.")
    {
        StartMessage();
        Console.WriteLine(GetRandomFromList(_prompts));
        Console.Write("You may begin in: ");
        Timer();
        Console.WriteLine();
        _timer = new System.Timers.Timer(_sessionLength * 1000);
        _timer.Elapsed += (sender, e) => _timeUp = true; 
        _timer.Start();
        _timer.AutoReset = false;

        while (!_timeUp)
        {
            Console.Write("> ");
            Console.ReadLine();

            listCount += 1;

        }
        _timer.Stop();
        _timer.Dispose();
        Console.WriteLine($"You listed {listCount} items!");
        EndMessage();
    }
}