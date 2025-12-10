

using System.ComponentModel;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public class GridMaker
{   
    private List<List<string>> _measureGrid = new List<List<string>>();
    private double _currentTime = 0; // start of measure
    private Measure _measure;
    
    public GridMaker (Measure ScoreMeasure)
    {
        _measure = ScoreMeasure;
    }
    public List<List<string>> CreateGrid()
{
    _currentTime = 0;
    _measureGrid = new List<List<string>>();
    double subdivision = 0.5; // eighth note

    string NoteToString(Note note)
    {
        return note.Step; 
    }

    double measureTime = 0;
    foreach (var note in _measure.Notes)
    {
        measureTime += note.Duration;
    }

    int totalSlots = (int)Math.Ceiling(measureTime / subdivision);

    // Create empty slots
    for (int i = 0; i < totalSlots; i++)
        _measureGrid.Add(new List<string>());

    // Fill the grid with notes
    foreach (var note in _measure.Notes)
    {
        int durationInSlots = (int)Math.Ceiling(note.Duration / subdivision);

        if (!note.IsChordWithPrevious)
            note.TimeOn = _currentTime;

        int startSlot = (int)Math.Floor(note.TimeOn / subdivision);
        int endSlot = startSlot + durationInSlots;

        for (int i = startSlot; i < endSlot; i++)
            _measureGrid[i].Add($"[{NoteToString(note)}]");

        if (!note.IsChordWithPrevious)
            _currentTime += note.Duration;
    }

    return _measureGrid;
}
    }