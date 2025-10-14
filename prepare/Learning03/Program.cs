using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test1 = new Fraction();
        Fraction test2 = new Fraction(5);
        Fraction test3 = new Fraction(2, 3);
        // test1.SetBottom(5);
        // Console.WriteLine(test1.GetBottom());
        // Console.WriteLine(test3.GetDecimalValue());
        // Console.WriteLine(test3.GetFractionString());
        // test3.SetBottom(5);
        // Console.WriteLine(test3.GetDecimalValue());
        // Console.WriteLine(test3.GetFractionString());
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());
        Console.WriteLine(test2.GetFractionString());
        Console.WriteLine(test2.GetDecimalValue());
        Console.WriteLine(test3.GetFractionString());
        Console.WriteLine(test3.GetDecimalValue());

    }
}