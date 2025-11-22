using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net;
class Program
{
    // Added functionality while saving to keep the existing point count and add that to what is being saved, hence keep a grand point count that saves in the file.
    
    static void Main(string[] args)
    {
        int sumPoints = 0;
        List<Goal> goals = new List<Goal>();
        bool running = true;
        string fileName = "myFile.txt";
        void SaveFile()
        {
            Console.WriteLine("What is the name for the goal file? ");
            fileName = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {   
            if (!fileName.Contains("Earned Points:"))
                {
                    outputFile.WriteLine($"Earned Points: {sumPoints}");
                }
                   
            else
                {
                int oldEarnedPoints = 0;
                var lines = File.ReadAllLines(fileName).ToList();
                foreach (string line in lines)
                    {
                    if (line.StartsWith("Earned Points: "))
                    {
                    string numberPart = line.Substring("Earned Points: ".Length).Trim();

                    int.TryParse(numberPart, out oldEarnedPoints);
                    break;
                
                        }
                    }
                int combinedEarnedPoints = oldEarnedPoints + sumPoints;
                lines.RemoveAll(line => line.StartsWith("Earned Points: "));
                lines.Add($"Earned Points: {combinedEarnedPoints}");
                File.WriteAllLines(fileName, lines);
                }
            foreach (Goal goal in goals)
                {
                    void WriteGoal()
                    {   
                        outputFile.Write($"{goal.GetType()}:{goal.GetGoal()}*{goal.GetDescription()}*{goal.GetPointsForSave()}");
                        outputFile.WriteLine();
                    }
                if (goal is Checklist checklistGoal)
                    {
    
                    outputFile.Write($"{goal.GetType()}:{goal.GetGoal()}*({checklistGoal.GetSavedDescription()})*");
                    outputFile.Write($"{checklistGoal.GetCompletedTimes()}/{checklistGoal.GetChecklistCount()}*");
                    outputFile.Write($"{goal.GetPoints()}");
                    outputFile.Write( $"*{checklistGoal.GetBonusPoints()}");
                    outputFile.WriteLine();

                    }
                else if (goal is Simple simpleGoal)
                    {
                        if (simpleGoal.GetStatus().Contains("[X]")) 
                        {
                            outputFile.Write("$");
                        }
                        WriteGoal();
                    }
                else
                {
                    WriteGoal();
                } } }
                goals.Clear();
                sumPoints = 0;
                
                }
        void ListGoals()
        {
            int count = 0;
            foreach (Goal goal in goals)
                    {
                        count += 1;
                        Console.WriteLine($"{count}. {goal.GetStatus()} {goal.GetGoal()} ({goal.GetDescription()})");
                    }
        }
        void LoadFile()
        {
            Console.WriteLine("What file do you want to load goals from? ");
            string loadFile = Console.ReadLine();
            if (File.Exists(loadFile))
            {
                string[] contents = File.ReadAllLines(loadFile);
                foreach (string line in contents.Skip(1))
                    {
                        string[] parts = line.Split('*');
                        string[] firstPartSplit = parts[0].Split(':');
                        string loadGoal = firstPartSplit[1];
                        string loadDescription = parts[1];
        
                        
                        
                        if (line.Contains("Simple"))
                        {
                            int loadPoints = int.Parse(parts[2]);
                            Goal simpleGoal = new Simple(loadGoal, loadDescription, loadPoints);
                            goals.Add(simpleGoal);
                            if (firstPartSplit[0].Contains('$'))
                            {
                            simpleGoal.SetStatusComplete();
                            }
                        }
                        else if (line.Contains("Eternal"))
                        {
                            int loadPoints = int.Parse(parts[2]);
                            Goal eternalGoal = new Eternal(loadGoal, loadDescription, loadPoints);
                            goals.Add(eternalGoal);
                        }
                        else if (line.Contains("Checklist"))
                        {
                            int loadPoints = int.Parse(parts[3]);
                            int loadBonusPoints = int.Parse(parts[4]);
                            string[] thirdPartSplit = parts[2].Split('/');
                            int loadChecklistCount = int.Parse(thirdPartSplit[1]);
                            int completedCount = int.Parse(thirdPartSplit[0]);
                            Goal checklistGoal = new Checklist(loadGoal, loadDescription, loadPoints, loadBonusPoints, completedCount, loadChecklistCount);
                            goals.Add(checklistGoal);
                        }
                    }
                
            }
            
            else
            {
                Console.WriteLine("Sorry, that is not a valid file name in folder. ");
            }
        }
        while (running)
        {
            Console.WriteLine($"You have {sumPoints} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal: ");
            Console.WriteLine("2. List Goals: ");
            Console.WriteLine("3. Save Goal: ");
            Console.WriteLine("4. Load Goal: ");
            Console.WriteLine("5. Record Event: ");
            Console.WriteLine("6. Quit: ");
            Console.WriteLine("Select a choice from the menu: ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                Console.WriteLine("Please select a type of goal to create: ");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                string goalType = Console.ReadLine();
                Console.WriteLine("What is the name of the goal? ");
                string goal = Console.ReadLine();
                Console.WriteLine("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                    if (goalType == "1")
                    {
                        Goal simpleGoal = new Simple(goal, description, points);
                        goals.Add(simpleGoal);
                    }
                    else if (goalType == "2")
                    {
                        Goal eternalGoal = new Eternal(goal, description, points);
                        goals.Add(eternalGoal);
                        
                    }
                    else if (goalType == "3")
                    {
                        Console.WriteLine("How many times does this goal need to be accomplished to recieve a bonus?");
                        int checklistCount = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the bonus for accomplishing it that many times? ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        Goal checklistGoal = new Checklist(goal, description, points, bonusPoints, 0, checklistCount);
                        goals.Add(checklistGoal);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, exiting to main menu.");
                    }
                break;

                case "2":
                    ListGoals();
                break;

                case "3":
                    SaveFile();
                break;

                case "4":
                    LoadFile();
                break;

                case "5":
                    Console.WriteLine("The goals are:");
                    ListGoals();
                    Console.WriteLine("Which goal did you accomplish? ");
                    int accomplishedGoal = int.Parse(Console.ReadLine());
                    int index = accomplishedGoal - 1;
                    sumPoints += goals[index].GetPoints();
                    goals[index].RecordEvent();
                break;

                case "6":
                    running = false;
                break;

            }
    
        }







    }
}