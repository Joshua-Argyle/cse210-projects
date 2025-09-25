using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {   
        List<int> numbers = new List<int>();
        List<int> positiveNumbers = new List<int>();
        int userNumber = 1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

        while (userNumber != 0)
        {

            Console.Write("Enter Number: ");
            userNumber = int.Parse(Console.ReadLine());
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
            if (userNumber > 0)
            {
                positiveNumbers.Add(userNumber);
            }
        }
        int smallestPositive = positiveNumbers.Min();
        
        double average = numbers.Sum() / numbers.Count;
        Console.WriteLine($"The sum is {numbers.Sum()}.");
        Console.WriteLine($"The average is {average}.");
        Console.WriteLine($"The largest number in the list is {numbers.Max()}.");
        Console.WriteLine($"The smallest positive number is {smallestPositive}");
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        
    }
}