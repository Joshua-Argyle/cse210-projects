using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Manufaktura.Music.Model;
using MusicXml.Domain;

class Program
{
    static void Main(string[] args)
    {
        List<Score> scores = new List<Score>();
        List<List<string>> scoreAccompanimentData = new List<List<string>>();
        List<string> measureNumbers = new List<string>();
        List<string> measureDivisions = new List<string>();
        List<string> measureBeats = new List<string>();
        List<string> measureBeatType = new List<string>();
        List<string> measureKey = new List<string>();
        string fileName = "untitled.musicxml";
        
        int intChoice = 0;
        string style;
        string staff = "1";
        string clef2 = "";
       
        string newChord;
        void LoadMusicFile()
        {
            Console.Write("What music.xml file would you like to load into the program? ");
            string musicFile = "jingle_bells.musicxml";
            /*
            string musicFile = Console.ReadLine();
            if (!File.Exists(musicFile))
            {
                Console.WriteLine("Please Select a Valid music.xml file that is piano only.");
                return;
            }
            */

            XDocument musicContents = XDocument.Load(musicFile);
            Score score = MusicParser.ParseScore(musicContents);
            scores.Add(score);
        }

        LoadMusicFile();
        





        
        Console.WriteLine("Welcome to the music accompaniment program, where you can turn any piano piece into an accompaniment of different style!");
        Console.WriteLine();
        string choice = "";
        bool run = true;
        while (run)
        {
            Console.WriteLine("What style would you like to generate? (Please enter a number between 1 and 5)");
            Console.WriteLine();
            Console.WriteLine("1. Lead Sheet (empty staff with chords)");
            Console.WriteLine("2. Ragtime Style");
            Console.WriteLine("3. Jazz Ballad");
            Console.WriteLine("4. Contemporary");
            Console.WriteLine("5. Bossa Nova");
            Console.WriteLine("6. Quit");
            Console.WriteLine();
            choice = Console.ReadLine();
        try
            {
                intChoice = int.Parse(choice);
            }
        catch (FormatException)
            {
            intChoice = 7;
            }
                switch (intChoice)
        {
            case 1:
                style = "leadSheet";
                CreateFile();
                Console.WriteLine();
                Console.WriteLine("Lead Sheet for jingle bells created successfully!");
                Console.WriteLine();
                Console.WriteLine();
                break;

            case 2:
                style = "ragtime";
                CreateFile();
                Console.WriteLine();
                Console.WriteLine("Ragtime Style of jingle bells created successfully!");
                Console.WriteLine();
                Console.WriteLine();
                break;

            case 3:
                style = "jazzBallad";
                CreateFile();
                Console.WriteLine();
                Console.WriteLine("Jazz Ballad Style of jingle bells created successfully!");
                Console.WriteLine();
                Console.WriteLine();
                break;
            case 4:
                style = "contemporary";
                CreateFile();
                Console.WriteLine();
                Console.WriteLine("Contemporary Style of jingle bells created successfully!");
                Console.WriteLine();
                Console.WriteLine();
                break;

            case 5:
                style = "bossaNova";
                CreateFile();
                Console.WriteLine();
                Console.WriteLine("Bossa Nova Style of jingle bells created successfully!");
                Console.WriteLine();
                Console.WriteLine();
                break;

            case 6:
                run = false;
                break;

            case 7: 
            Console.WriteLine("Please select a valid option. ");
            break;
        }
        }
        void CreateFile() {
        foreach (Measure measure in scores[0].Measures)
        {   

                
            measureNumbers.Add(measure.Number.ToString());
            measureDivisions.Add(measure.Divisions.ToString());
            measureBeats.Add(measure.Beats.ToString());
            measureBeatType.Add(measure.BeatType.ToString());
            measureKey.Add(measure.Key);
            
            List<string> measureChords = new List<string>();
            GridMaker measureGrid = new GridMaker(measure);
            ChordIdentifier Identifier = new ChordIdentifier(measureGrid);
            List<string> values = new List<string>();
            List<int> durations = new List<int>();
            List<string> chords = Identifier.GetChordsAndDurations();
            foreach (string chord in chords)
            {
                
                string[] parts;
                parts = chord.Split(':');
                string value = parts[0];
                int duration = int.Parse(parts[1].Trim());
                values.Add(value);
                durations.Add(duration);

            }
            
            for (int i = 0; i < values.Count();) 
            {
                int runningDurations = durations[i];
            
                int j = i + 1;

                if (j < values.Count() && values[i] == values[j])
                {
                    while (j < values.Count() && values[i] == values[j])
                    {
                        runningDurations += durations[j]; 
                        j++; 
                    }
                    
                    string newDuration = runningDurations.ToString();
                    newChord = $"{values[i]}:{newDuration}";
                    measureChords.Add(newChord);
                  
                    i = j; 
                }
                
                else 
                {

                    newChord = $"{values[i]}:{durations[i]}";
                    measureChords.Add(newChord);
                
                    i++; 
                }
            }
            
        scoreAccompanimentData.Add(measureChords);
        }
        
    Ragtime ragtime = new Ragtime(scoreAccompanimentData);
    LeadSheetGenerator leadSheet = new LeadSheetGenerator(scoreAccompanimentData);
    Contemporary contemporary = new Contemporary(scoreAccompanimentData);
    JazzBallad jazzBallad = new JazzBallad(scoreAccompanimentData);
    BossaNova bossaNova = new BossaNova(scoreAccompanimentData);
        string outputDirectory = "ConvertedMusic"; 
        
        if (style == "leadSheet")
            {
                fileName = "untitledLeadSheet.musicxml";
            }
        else if (style == "ragtime") 
            {
                fileName = "untitledRagtime.musicxml";
            }
        else if (style == "jazzBallad") 
            {
                fileName = "untitledJazzBallad.musicxml";
            }
        else if (style == "contemporary") 
            {
                fileName = "untitledContemporary.musicxml";
            }
        else if (style == "bossaNova") 
            {
                fileName = "untitledBossaNova.musicxml";
            }
        
        string fullPath = Path.Combine(outputDirectory, fileName);
        string directoryToCreate = Path.GetDirectoryName(fullPath);
        if (!string.IsNullOrEmpty(directoryToCreate) && !Directory.Exists(directoryToCreate))
        {
            Directory.CreateDirectory(directoryToCreate);
        }
    
string composer = "Piano Accompaniment Program";
using (StreamWriter outputFile = new StreamWriter(fullPath)) {
    
string musicXmlHeader = $@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
<!DOCTYPE score-partwise PUBLIC
    ""-//Recordare//DTD MusicXML 4.0 Partwise//EN""
    ""http://www.musicxml.org/dtds/partwise.dtd"">
<score-partwise version=""4.0"">
    
    <identification>
        <creator type=""composer"">{composer}</creator>
        <rights>Copyright © 2025</rights>
        <encoding>
            <software>Chord Identifier Program</software>
        </encoding>
    </identification>

    <part-list>
        <score-part id=""P1"">
            <part-name>Lead Sheet</part-name>
            <score-instrument id=""P1-I1"">
                <instrument-name>Piano</instrument-name>
            </score-instrument>
        </score-part>
    </part-list>

    <part id=""P1"">
";
outputFile.WriteLine(musicXmlHeader);
if (style == "leadSheet")
                {
                   staff = "1";
                }
else
                {
                    staff = "2";
                }

for (int i = 0; i < scoreAccompanimentData.Count(); i++)
        {
            string measureContent = $@"<measure number=""{measureNumbers[i]}"">
    <attributes>";
            outputFile.WriteLine(measureContent);
            
            if (i == 0 || measureDivisions[i - 1] != measureDivisions[i]) {
            string measureAttributes = $@"
    
        <divisions>{measureDivisions[i]}</divisions>";
            outputFile.WriteLine(measureAttributes);
            }
             if (i == 0 || measureKey[i - 1] != measureKey[i]) {
            string measureAttributes = $@"
        <key>
            <fifths>{measureKey[i]}</fifths>
        </key>";
    
            outputFile.WriteLine(measureAttributes);
            }
            
            if (i == 0 || measureBeatType[i - 1] != measureBeatType[i]) {
            string measureAttributes = $@"
        <time>
            <beats>{measureBeats[i]}</beats>
            <beat-type>{measureBeatType[i]}</beat-type>
        </time>";
            outputFile.WriteLine(measureAttributes);
            }
        
            string clef = $@"
        <clef number=""1"">
          <sign>G</sign>
          <line>2</line>
        </clef>";
            
        clef2 = $@"<clef number=""2"">
          <sign>F</sign>
          <line>4</line>
        </clef>
            ";
            outputFile.WriteLine(clef);
            if (style != "leadSheet")
                    {
                        outputFile.WriteLine(clef2);
                    }
            string measureAttributeEnd = $@"<staves>{staff}</staves>
        </attributes>";
            outputFile.WriteLine(measureAttributeEnd);
            foreach(string chord in scoreAccompanimentData[i])
            {
        if (style == "leadSheet") 
        {       
        outputFile.WriteLine(leadSheet.RythmnMaker()[i]);
        }

        else if (style == "ragtime")
        {
        outputFile.WriteLine(ragtime.RythmnMaker()[i]);               
        }

         else if (style == "jazzBallad")
        {
        outputFile.WriteLine(jazzBallad.RythmnMaker()[i]);               
        }

         else if (style == "contemporary")
        {
        outputFile.WriteLine(contemporary.RythmnMaker()[i]);               
        }

         else if (style == "bossaNova")
        {
        outputFile.WriteLine(bossaNova.RythmnMaker()[i]);               
        }
        }
        string measureEnd = $"</measure>";
        outputFile.WriteLine(measureEnd);
    }
string musicXmlFooter = @"
<direction placement=""above"">
    <direction-type>
        <words enclosure=""none"" font-weight=""bold"">Fine</words>
    </direction-type>
</direction>

</part>
</score-partwise>";
    outputFile.Write(musicXmlFooter);
    scoreAccompanimentData.Clear();
} }
}}