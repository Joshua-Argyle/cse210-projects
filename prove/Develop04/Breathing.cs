using System.ComponentModel;

public class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity will guide you through a steady breathing exercise that will calm you down and ease your mind.")
    {
        StartMessage();
        
            if (_sessionLength >= 30)
                {
                    numbers.Insert(0, "5");
                }
            while (_sessionLength >= 0)
        {
            Console.Write("Breathe In...");
            Timer();
            Console.WriteLine();
            Console.WriteLine("Breath Out...");
            Timer();
            Console.WriteLine();
            _sessionLength -= 8;
        
        }
        EndMessage();
    }
}