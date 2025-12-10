public class Note
{
    public string Step { get; set; }      // C, D, E, etc.
    public int Octave { get; set; }       // 4, 5, etc.
    public double Duration { get; set; }  // in divisions
    public bool IsRest { get; set; }      // true if <rest/>
    public int Staff { get; set; }  // staff right or left hand
    public double TimeOn { get; set; } //When note starts
    public bool IsChordWithPrevious { get; set; } = false;
    
    
}