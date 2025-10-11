using System;
using System.Net.Quic;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
// I added a few prompts specific to holidays, so that if it is that holiday the prompt chosen will be related to that holiday.
class Program
{
    static void Main(string[] args)
    {
        int choice = 0;


        while (choice != 5)
        {
            Console.WriteLine("Welcome to your journal! Please Select an Option (1 - 5)");
            Console.WriteLine("1. Write New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to a file");
            Console.WriteLine("4. Load Journal from a file");
            Console.WriteLine("5. Quit Program");
            JournalEntry entry = new JournalEntry();
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                JournalEntry.PromptGenerator();
                Console.Write($"{JournalEntry._dateText}     ");
                Console.WriteLine(JournalEntry._prompt);
                entry._entry = Console.ReadLine();
                Journal._entryList.Add(entry);
                Console.WriteLine("            ");
            }

            else if (choice == 2)
            {
                Journal.DisplayFile();
            }

            else if (choice == 3)
            {

                entry.SaveFile();
            }

            else if (choice == 4)
            {
                Journal.LoadFile();
            }

            else if (choice == 5)
            {
                Console.WriteLine("Thanks for checking out the journal!");
            }
            else if (choice > 5 || choice < 1)
            {
                Console.WriteLine("Please Select a number between 1 and 5.");
            }

        }
    }
}
