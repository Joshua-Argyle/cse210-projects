using System;
// I added in my breathing activity an option for when their is more time, to insert a long breathing interval.
class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running) {
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listening Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Please select an option (1-4): ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Breathing b = new Breathing();
                    break;
                case "2":
                    Reflection r = new Reflection();
                    break;
                case "3":
                    Listening l = new Listening();
                    break;
                case "4":
                    Console.WriteLine();
                    Console.WriteLine("Thanks for checking out the activities!");
                    running = false;
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}