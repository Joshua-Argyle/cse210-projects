using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using Manufaktura.Music.Model;
using Microsoft.VisualBasic;

public class ChordIdentifier
{
    

    private List<string> _chordsAndDurations = new List<string>();
           
    private List<int> _numberedSlot;
    private List<List<int>> _numberedGrid= new List<List<int>>();
    public List<string> GetChordsAndDurations()
    {
        return _chordsAndDurations;
    }
    
    public ChordIdentifier(GridMaker measureGrid)
    {
        double duration = 1;

        var grid = measureGrid.CreateGrid(); 
        foreach (List<string> slot in grid)
        {
            _numberedSlot = NotesToNumbers(slot);
            _numberedGrid.Add(_numberedSlot);
            
        } 
        for (int i = 0; i < _numberedGrid.Count(); i++)
        {
            
            var slot = _numberedGrid[i];

            if (slot.Count < 3)
            {
                if (i + 1 == _numberedGrid.Count)
                {
                    string lastItem = _chordsAndDurations.Last();
                    string[] parts = lastItem.Split(':');
                    if (lastItem.Contains(":")) {
                           _chordsAndDurations.Add($"{parts[0]}:{duration}"); 
                        }
                    else
                        {
                            _chordsAndDurations.Add($"No Chord Found In Measure {duration}");
                        }
                }
                else {
                var nextSlot = _numberedGrid[i + 1];
                
                nextSlot.AddRange(slot);

                slot.Clear();

                duration += 1;
                
                }

            }
            
            //Check if it is a domninant 7 chord
            if (slot.Count >= 3) {
                double previousDuration = duration;
    
            if (slot.Contains(1) && slot.Contains(5) && slot.Contains(8) && slot.Contains(11)) {

                _chordsAndDurations.Add($"C Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(2) && slot.Contains(6) && slot.Contains(9) && slot.Contains(12))
            {
                _chordsAndDurations.Add($"Db Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(3) && slot.Contains(7) && slot.Contains(10) && slot.Contains(1))
            {
                _chordsAndDurations.Add($"D Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(4) && slot.Contains(8) && slot.Contains(11) && slot.Contains(2))
            {
                _chordsAndDurations.Add($"Eb Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(5) && slot.Contains(9) && slot.Contains(12) && slot.Contains(3))
            {
                _chordsAndDurations.Add($"E Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(6) && slot.Contains(10) && slot.Contains(1) && slot.Contains(4))
            {
                _chordsAndDurations.Add($"F Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(7) && slot.Contains(11) && slot.Contains(2) && slot.Contains(5))
            {
                _chordsAndDurations.Add($"F# Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(8) && slot.Contains(12) && slot.Contains(3) && slot.Contains(6))
            {
                _chordsAndDurations.Add($"G Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(9) && slot.Contains(1) && slot.Contains(4) && slot.Contains(7))
            {
                _chordsAndDurations.Add($"Ab Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(10) && slot.Contains(2) && slot.Contains(5) && slot.Contains(8))
            {
                _chordsAndDurations.Add($"A Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(11) && slot.Contains(3) && slot.Contains(6) && slot.Contains(9))
            {
                _chordsAndDurations.Add($"Bb Dominant 7 :{duration}");
                duration = 1;
            }
            else if (slot.Contains(12) && slot.Contains(4) && slot.Contains(7) && slot.Contains(10))
            {
                _chordsAndDurations.Add($"B Dominant 7 :{duration}");
                duration = 1;
            }

            //Check if it is major
            
            else if (slot.Contains(1) && slot.Contains(5) && slot.Contains(8)) {

                _chordsAndDurations.Add($"C Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(2) && slot.Contains(6) && slot.Contains(9))
            {
                _chordsAndDurations.Add($"Db Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(3) && slot.Contains(7) && slot.Contains(10))
            {
                _chordsAndDurations.Add($"D Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(4) && slot.Contains(8) && slot.Contains(11))
            {
                _chordsAndDurations.Add($"Eb Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(5) && slot.Contains(9) && slot.Contains(12))
            {
                _chordsAndDurations.Add($"E Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(6) && slot.Contains(10) && slot.Contains(1))
            {
                _chordsAndDurations.Add($"F Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(7) && slot.Contains(11) && slot.Contains(2))
            {
                _chordsAndDurations.Add($"F# Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(8) && slot.Contains(12) && slot.Contains(3))
            {

                _chordsAndDurations.Add($"G Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(9) && slot.Contains(1) && slot.Contains(4))
            {
                _chordsAndDurations.Add($"Ab Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(10) && slot.Contains(2) && slot.Contains(5))
            {
                _chordsAndDurations.Add($"A Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(11) && slot.Contains(3) && slot.Contains(6))
            {
                _chordsAndDurations.Add($"Bb Major :{duration}");
                duration = 1;
            }
            else if (slot.Contains(12) && slot.Contains(4) && slot.Contains(7))
            {
                _chordsAndDurations.Add($"B Major :{duration}");
                duration = 1;
            }

            //check if it is minor

            else if (slot.Contains(1) && slot.Contains(4) && slot.Contains(8)) {

                _chordsAndDurations.Add($"C Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(2) && slot.Contains(5) && slot.Contains(9))
            {
                _chordsAndDurations.Add($"C# Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(3) && slot.Contains(6) && slot.Contains(10))
            {
                _chordsAndDurations.Add($"D Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(4) && slot.Contains(7) && slot.Contains(11))
            {
                _chordsAndDurations.Add($"Eb Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(5) && slot.Contains(8) && slot.Contains(12))
            {
                _chordsAndDurations.Add($"E Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(6) && slot.Contains(9) && slot.Contains(1))
            {
                _chordsAndDurations.Add($"F Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(7) && slot.Contains(10) && slot.Contains(2))
            {
                _chordsAndDurations.Add($"F# Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(8) && slot.Contains(11) && slot.Contains(3))
            {
                _chordsAndDurations.Add($"G Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(9) && slot.Contains(12) && slot.Contains(4))
            {
                _chordsAndDurations.Add($"Ab Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(10) && slot.Contains(1) && slot.Contains(5))
            {
                _chordsAndDurations.Add($"A Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(11) && slot.Contains(2) && slot.Contains(6))
            {
                _chordsAndDurations.Add($"Bb Minor :{duration}");
                duration = 1;
            }
            else if (slot.Contains(12) && slot.Contains(3) && slot.Contains(7))
            {
                _chordsAndDurations.Add($"B Minor :{duration}");
                duration = 1;
            }
            else
            {
                duration = previousDuration;
                if (i + 1 == _numberedGrid.Count)
            {
    
            if (_chordsAndDurations.Any())
            {
                string lastItem = _chordsAndDurations.Last(); 
                string[] parts = lastItem.Split(':');
                
                // ... (rest of your logic using lastItem) ...
                
                if (lastItem.Contains(":")) 
                {
                    // You are adding a duplicate entry here, which seems wrong, but 
                    // the crash is avoided. We just care about avoiding the crash for now.
                    _chordsAndDurations.Add($"{parts[0]}:{duration}"); 
                }
                else
                {
                    _chordsAndDurations.Add($"No Chord Found In Measure {duration}");
                }
            }
            else // The measure is entirely empty or only contained rests/arpeggios
            {
                // Handle the case where the whole measure is N.C.
                _chordsAndDurations.Add($"N.C. :{duration}");
            }
            }
                        else {
                        var nextSlot = _numberedGrid[i + 1];
                        
                        nextSlot.AddRange(slot);

                        slot.Clear();

                        duration += 1;
                        }
                    }
                    }
                    
                }
            } 
        
    public List<int> NotesToNumbers(List<string> slot)
    {
        List<int> _numberedNotes = new List<int>();

        foreach (var note in slot) 
        {

            if (note.Contains("[C]") || note.Contains("[B#]") || note.Contains("[Dbb]")) //Add if it is c flat or c sharp as well later
            {
                _numberedNotes.Add(1);
            }
            else if (note.Contains("[C#]") || note.Contains("[Db]") || note.Contains("B##"))
            {
                _numberedNotes.Add(2);
            }
            else if (note.Contains("[D]")|| note.Contains("[C##]") || note.Contains("Ebb"))
            {
                _numberedNotes.Add(3);
            }
            else if (note.Contains("[D#]")|| note.Contains("[Eb]"))
            {
                _numberedNotes.Add(4);
            }
            else if (note.Contains("[E]")|| note.Contains("[Fb]"))
            {
                _numberedNotes.Add(5);
            }
            else if (note.Contains("[F]")|| note.Contains("[E#]") || note.Contains("[Gbb]"))
            {
                _numberedNotes.Add(6);
            }
            else if (note.Contains("[F#]")|| note.Contains("[Gb]") || note.Contains("[E##]"))
            {
                _numberedNotes.Add(7);
            }
            else if (note.Contains("[G]")|| note.Contains("[Abb]") || note.Contains("[F##]"))
            {
                _numberedNotes.Add(8);
            }
            else if (note.Contains("[G#]")|| note.Contains("[Ab]"))
            {
                _numberedNotes.Add(9);
            }
            else if (note.Contains("[A]")|| note.Contains("[Bbb]") || note.Contains("[G##]"))
            {
                _numberedNotes.Add(10);
            }
            else if (note.Contains("[A#]")|| note.Contains("[Bb]") || note.Contains("[Cbb]"))
            {
                _numberedNotes.Add(11);
            }
            else if (note.Contains("[B]")|| note.Contains("[Cb]") || note.Contains("[A##]"))
            {
                _numberedNotes.Add(12);
            }
        }
        return _numberedNotes;
        
    }
    
}


