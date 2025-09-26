using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Welcome();
        string userName = DisplayName();
        int favoriteNumber = DisplayNumber();
        int birthYear;
        DisplayBirthYear(out birthYear);
        int squared = DisplayNumberSquared(favoriteNumber);
        DisplayResult(squared, userName, birthYear);


        static void Welcome()
        {
            Console.WriteLine("Welcome to the Program. ");
        }

        static string DisplayName()
        {
            Console.Write("What is your full name? ");
            string name = Console.ReadLine();

            return name;

        }

        static int DisplayNumber()
        {
            Console.Write("What is your favorite number? ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static void DisplayBirthYear(out int birthYear)
        {
            Console.Write("What year were you born? ");
            birthYear = int.Parse(Console.ReadLine());
        }
        static int DisplayNumberSquared(int number)
        {
            int squaredNumber = number * number;
            return squaredNumber;

        }
        static void DisplayResult(int squared, string userName, int birthYear)
        {
            int age = 2025 - birthYear;
            Console.WriteLine($"Your number squared is {squared}.");
            Console.WriteLine($"{userName}, you are turning {age} this year");
        }
    }
}