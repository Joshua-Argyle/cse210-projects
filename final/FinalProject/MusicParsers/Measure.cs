public class Measure
{
    public int Number { get; set; }
    public List<Note> Notes { get; set; } = new List<Note>();
    public int Divisions { get; set; }
    public int Beats { get; set; }
    public int BeatType { get; set; }
    public string Key { get; set; }
    public int Clef { get; set; }  // clef type

    
}