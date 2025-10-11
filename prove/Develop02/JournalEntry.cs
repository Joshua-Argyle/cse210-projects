using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
public class JournalEntry
{

    public static DateTime _currentTime = DateTime.Now;
    public static string _dateText = _currentTime.ToShortDateString();
    public static string _prompt;
    public static List<string> prompts = new List<string>


{
    "How have you seen the hand of the Lord in your life today?",
    "What are 3 things you learned today? ",
    "What was something funny that happened today? ",
    "What is something you want to do better than you did today? ",
    "Who did you help today? And if you can't think of anything, who would you like to help tomorrow? " ,
    "What made today specia1? ",
    "Who or what made you laugh today? " ,
    "What's on your mind? ",
};
    public string _entry;
    public static string PromptGenerator()
    {
        Random rand = new Random();
        if (_dateText.Contains("10/31"))
        {
            _prompt = "Happy Halloween! What is something spooky that happened today?.";
        }
        if (_dateText.Contains("11/23") || _dateText.Contains("11/24") || _dateText.Contains("11/25") || _dateText.Contains("11/26") || _dateText.Contains("11/27"))
        {
            _prompt = "Happy Thanksgiving! What is something you are grateful for?";
        }
        if (_dateText.Contains("12/25"))
        {
            _prompt = "Merry Christmas! What presents did you get and what family do you spend time with?";
        }
        if (_dateText.Contains("2/14"))
        {
            _prompt = "Happy Valentine's Day! Did you do something with a special someone?";
        }
        if (_dateText.Contains("3/17"))
        {
            _prompt = "Happy Saint Patrick's Day! Did you get pinched, if so what happened? If not, do anything special?";
        }
        else
        {
            _prompt = prompts[rand.Next(prompts.Count)];
        }
        return _prompt;

    }


    public void SaveFile()
    {
        string tryAgainSave = "y";
        while (tryAgainSave.ToLower() == "y")
        {
            Console.WriteLine("What file would you like to save your journal to? (Please include the full name with extension .csv/.txt ) ");
            string attemptedFileName = Console.ReadLine();

            if (File.Exists(Path.Combine(Journal.currentDirectory, attemptedFileName)))
            {
                Journal.fileName = attemptedFileName;
                Console.WriteLine($"Success! Journal saved to {attemptedFileName}.");
                Console.WriteLine("            ");
                tryAgainSave = "n";
                using (StreamWriter outputFile = new StreamWriter(Journal.fileName))
                {
                    foreach (JournalEntry entry in Journal._entryList)
                    {
                        outputFile.WriteLine($"{_dateText}    ");
                        outputFile.WriteLine(_prompt);
                        outputFile.WriteLine(entry._entry);
                        outputFile.WriteLine("     ~     ");
                    }
                }
            }
            else
            {
                Console.WriteLine("No such file found. Perhaps you misspelled it?");
                Console.WriteLine("Want to try typing it in again? (Y/N)");
                string answer = Console.ReadLine();
                tryAgainSave = answer;
            }


        }
    }
}