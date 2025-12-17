public class Accompaniment
{
    protected List<List<string>> _accompanimentData = new List<List<string>>();
    protected List<string> bodies = new List<string>();
    
    protected List<string> keys = new List<string>{"C","C#","D","D#","E","F","F#", "G", "G#", "A", "A#", "B", "C","C#","D","D#","E","F","F#", "G", "G#", "A", "A#", "B"};
    protected string alter = "0";
public Accompaniment(List<List<string>> accompanimentData)
    {
       _accompanimentData = accompanimentData; 
    }

public List<string> RythmnMaker()
    {
        return bodies;
    }

public string AccidentalParser(string note)
    {
        if (note.Contains("#"))
                    {
                        string[] parts = note.Split('#');
                            return parts[0];
                    }
                    else if (note.Contains("b"))
                    {
                        string[] parts = note.Split("b");
                            return parts[0];
                    }
                    else if (note.Contains("##"))
                    {
                        string[] parts = note.Split("##");
                            return parts[0];
                    }
                    else if (note.Contains("bb"))
                    {
                        string[] parts = note.Split("bb");
                            return parts[0];
                    }
                    else
                    {
                        return note;
                    }
                }
    
public string AccidentalMaker(string note)
                {
                    if (note.Contains("#"))
                    {
                        alter = "1";
                    
                        return alter;
                    }
                    else if (note.Contains("b"))
                    {
                        alter = "-1";
                        return alter;
                    }
                    else if (note.Contains("##"))
                    {
                        alter = "2";
                        return alter;
                    }
                    else if (note.Contains("bb"))
                    {
                        alter = "-2";
                        return alter;
                    }
                    else
                    {
                        alter = "0";
                        return alter;
                    }
                }
}