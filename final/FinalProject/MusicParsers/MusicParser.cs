using System.Xml.Linq;
using System.Collections.Generic;

public static class MusicParser
{
    public static Score ParseScore(XDocument doc)
    {
        var score = new Score();
        XNamespace ns = doc.Root.Name.Namespace;

            foreach (var measureElem in doc.Descendants(ns + "measure"))
            {
                var measure = new Measure();
                measure.Number = int.Parse(measureElem.Attribute("number")?.Value ?? "0");

                foreach (var noteElem in measureElem.Elements(ns + "note"))
                {
                    var note = new Note();
                    note.IsRest = noteElem.Element(ns + "rest") != null;

                    if (!note.IsRest)
                    {
                        var pitch = noteElem.Element(ns + "pitch");
                        note.Step = pitch.Element(ns + "step")?.Value;
                        note.Octave = int.Parse(pitch.Element(ns + "octave")?.Value ?? "0");
                    }

                    note.Duration = double.Parse(noteElem.Element(ns + "duration")?.Value ?? "0");
                    var staffElem = noteElem.Element(ns + "staff");
                    note.Staff = staffElem != null ? int.Parse(staffElem.Value) : 1;
                    note.IsChordWithPrevious = noteElem.Element(ns + "chord") != null;
                    measure.Notes.Add(note);
                }

                score.Measures.Add(measure);
            }
           

        return score; 
        }

        
}
