

using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public class GridMaker
{   
    private List<List<string>> _measureGrid = new List<List<string>>();
    private double _currentTime; 
    private double _chordPrevious;
    private Measure _measure;
    int totalSlots = 0;
    
    public List<List<string>> GetMeasureGrid()
    {
        return _measureGrid;
    }
    
    public GridMaker (Measure ScoreMeasure)
    {
        _measure = ScoreMeasure;
        totalSlots = ScoreMeasure.Beats * ScoreMeasure.Divisions;
    }
    public List<List<string>> CreateGrid()
    {
    
   
    _measureGrid = new List<List<string>>();

    string NoteToString(Note note)
    {
        return $"{note.Step}{note.Accidental}"; 
    }
    
    
    

   
    for (int i = 0; i < totalSlots; i++)
        _measureGrid.Add(new List<string>());

   var staffs = _measure.Notes.Select(n => n.Staff).Distinct();

    foreach (var staff in staffs)
    {
    // Filter notes for this staff
    var staffNotes = _measure.Notes.Where(n => n.Staff == staff);
    // Fill the grid with notes
     _currentTime = 0;
     _chordPrevious = 0;
    foreach (var note in staffNotes)
    {
        int durationInSlots = (int)Math.Ceiling(note.Duration);
        if (!note.IsChordWithPrevious)
                {
                    note.TimeOn = _currentTime;
                }
        else
                {
                    note.TimeOn = _chordPrevious;
                }

        int startSlot = (int)Math.Floor(note.TimeOn);
        int endSlot = startSlot + durationInSlots;

        for (int i = startSlot; i < endSlot && i < totalSlots; i++)
            _measureGrid[i].Add($"[{NoteToString(note)}]");

        if (!note.IsChordWithPrevious)
        {
            _chordPrevious = _currentTime;
            _currentTime += durationInSlots;
        }

    }
    }
    return _measureGrid;
}
    }