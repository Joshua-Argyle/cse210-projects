using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "y";
        const int rangeMax = 101;
        while (playAgain.ToLower() == "y")
        {
            Random numberGenerator = new Random();
            int magicNumber = numberGenerator.Next(1, rangeMax);
            int guess;
            int count = 0;
            do
            {
                count += 1;
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess == magicNumber)
                {
                    Console.WriteLine($"You guessed it! Took {count} tries. ");
                }
            } while (magicNumber != guess);
            Console.Write("Play Again? (y or n) ");
            playAgain = Console.ReadLine();
        }
        Console.Write("Thanks for playing!");
    }
}
