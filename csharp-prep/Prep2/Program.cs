using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string sign = "";
        string letter = "grade";
        Console.Write("What is your grade? ");
        int grade = int.Parse(Console.ReadLine());
        if (grade >= 94)
        {
            sign = "";
            letter = "A";
        }
        else if (grade <= 59)
        {
            sign = "";
            letter = "F";
        }
        else
        {
            if (grade >= 90)
            {
                letter = "A";
            }
            else if (grade >= 80 && grade < 90)
            {
                letter = "B";
            }
            else if (grade >= 70 && grade < 80)
            {
                letter = "C";
            }
            else if (grade >= 60 && grade < 70)
            {
                letter = "D";
            }

            if ((grade % 10) >= 7 && (grade % 10) <= 9)
            {
                sign = "+";
            }
            else if ((grade % 10) >= 0 && (grade % 10) <= 3)
            {
                sign = "-";
            }
        }
        Console.WriteLine($"{letter}{sign}");
        if (grade >= 70)
        {
            Console.WriteLine("Congrats, you passed the class. ");
        }
        else
        {
            Console.WriteLine("I'm sorry, try again next time! ");
        }
    }
}