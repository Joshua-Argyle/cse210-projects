using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;
public class Journal {
    
    public static List<JournalEntry> _entryList = new List<JournalEntry>();
    public static string fileName = "Journal.csv";
    public static string currentDirectory = Directory.GetCurrentDirectory();
    public static string fullPath = Path.Combine(currentDirectory, fileName);

    public static void DisplayFile()
    {

        foreach (JournalEntry entry in _entryList)
    {
            Console.WriteLine($"{JournalEntry._dateText}    ");
            Console.WriteLine(JournalEntry._prompt);
            Console.WriteLine(entry._entry);
            Console.WriteLine("     ~     ");
    }
    }
    public static void LoadFile()
    {
        string tryAgain = "y";
        while (tryAgain.ToLower() == "y") {
            Console.WriteLine("What journal would you like to load? (Please include the full name with extension .csv/.txt ) ");
            string attemptedFileName = Console.ReadLine();
            
            if (File.Exists(Path.Combine(currentDirectory, attemptedFileName)))
            {
                fileName = attemptedFileName;
                Console.WriteLine($"Success! {attemptedFileName} loaded.");
                tryAgain = "n";
                _entryList = [];
            }
            else
            {
                Console.WriteLine("No such file found. Perhaps you misspelled it?");
                Console.WriteLine("Want to try typing it in again? (Y/N)");
                string answer = Console.ReadLine();
                tryAgain = answer;
            }
        } }
}