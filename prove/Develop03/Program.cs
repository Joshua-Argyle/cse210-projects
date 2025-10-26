using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        Scripture ThisScripture = new Scripture();
        Reference ThisReference = new Reference();
        List<string> hiddenScripture = new List<string>();
        Console.WriteLine("Welcome to the scripture memorizer! Press ENTER to hide more words! press q to quit.");
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", ThisScripture._scriptures));

        while (quit == false && ThisScripture._scriptures.Any(word => !word.Contains("_")))
        {

            string input = Console.ReadLine();
            if (input == "")
            {
                hiddenScripture = ThisScripture.HideWords(ThisScripture._scriptures);
                string fluidScripture = string.Join(", ", hiddenScripture);
                Console.WriteLine(fluidScripture);
                Console.WriteLine(ThisReference.DisplayReferenceOneVerse());
                ThisScripture._scriptures = hiddenScripture;

            }
            else if (input.ToLower() == "q")
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Please press ENTER of q.");
            }

        }
        Console.WriteLine("");
        Console.WriteLine("Thanks for studying up!");
    }
}