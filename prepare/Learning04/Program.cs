using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment Math1 = new MathAssignment("Josh", "Fractions", "2.5", "4-16");
        WritingAssignment Writing1 = new WritingAssignment("Lily", "American History", "The Adventures of Abraham Licoln");
        Console.WriteLine(Math1.GetSummary());
        Console.WriteLine(Math1.GetHomeWorkList());

        Console.WriteLine(Writing1.GetSummary());
        Console.WriteLine(Writing1.GetInformation());
    }
}