using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using Manufaktura.Music.Model;

class Program
{
    static void Main(string[] args)
    {
        List<Score> scores = new List<Score>();

        void LoadMusicFile()
        {
            Console.Write("What music.xml file would you like to load into the program? ");
            string musicFile = "Jingle_bells.musicxml";
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
        
        
        foreach (Measure measure in scores[0].Measures)
        {
            GridMaker measureGrid = new GridMaker(measure);
            
            foreach (var slot in measureGrid.CreateGrid())
                {
                if (slot.Count == 0)
                    Console.WriteLine("");  // empty slot
                else
                    Console.WriteLine(string.Join(" ", slot)); 
                }
            Console.WriteLine();
        }
        
            
            
    }
}