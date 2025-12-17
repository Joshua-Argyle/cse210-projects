using System.Xml.Linq;
using System.Collections.Generic;

public static class MusicParser
{
    public static Score ParseScore(XDocument doc)
    {
        var score = new Score();
        XNamespace ns = doc.Root.Name.Namespace;

        // --- ATTRIBUTE INHERITANCE: Set persistent variables outside the loop ---
        // Initialize with safe defaults (0 or 4 is common for divisions/time)
        int currentDivisions = 4;
        int currentBeats = 4;
        int currentBeatType = 4;
        string currentKeyFifths = "0"; // String for fifths (sharps/flats count)

        foreach (var measureElem in doc.Descendants(ns + "measure"))
        {
            var measure = new Measure { Notes = new List<Note>() };
            
            // 1. Always parse the Measure Number (Attribute of <measure>)
            measure.Number = int.Parse(measureElem.Attribute("number")?.Value ?? "0");

            // 2. CHECK FOR ATTRIBUTE CHANGES (time, divisions, key)
            var attributesElem = measureElem.Element(ns + "attributes");

            if (attributesElem != null)
            {
                // A. Update currentDivisions
                var divisionsElem = attributesElem.Element(ns + "divisions");
                if (divisionsElem != null)
                {
                    // Update the persistent variable with the new value
                    currentDivisions = int.Parse(divisionsElem.Value);
                }

                // B. Update currentTime
                var timeElem = attributesElem.Element(ns + "time");
                if (timeElem != null)
                {
                    // Update persistent variables, using their own current value as fallback
                    currentBeats = int.Parse(timeElem.Element(ns + "beats")?.Value ?? currentBeats.ToString());
                    currentBeatType = int.Parse(timeElem.Element(ns + "beat-type")?.Value ?? currentBeatType.ToString());
                }

                // C. Update currentKey
                var keyElem = attributesElem.Element(ns + "key");
                if (keyElem != null)
                {
                    // Update persistent variable for fifths
                    currentKeyFifths = keyElem.Element(ns + "fifths")?.Value ?? currentKeyFifths;
                }
            }
            
            // 3. APPLY CURRENT CONTEXT (Inheritance)
            // Assign the latest known values (whether updated in this measure or inherited) 
            // to the measure object. This ensures all measures have context.
            measure.Divisions = currentDivisions;
            measure.Beats = currentBeats;
            measure.BeatType = currentBeatType;
            measure.Key = currentKeyFifths; // Assuming 'Key' property holds the fifths value

            // 4. Parse Notes and Rests (Your existing, correct logic)
            foreach (var noteElem in measureElem.Elements(ns + "note"))
            {
                var note = new Note();
                note.IsRest = noteElem.Element(ns + "rest") != null;

                if (!note.IsRest)
                {
                    // Pitch details
                    var pitch = noteElem.Element(ns + "pitch");
                    note.Step = pitch.Element(ns + "step")?.Value;
                    note.Octave = int.Parse(pitch.Element(ns + "octave")?.Value ?? "0");

                    // Alter parsing (for accidentals, handling both <alter> and <accidental>)
                    var alterElem = pitch.Element(ns + "alter");
                    if (alterElem != null)
                    {
                        int alterValue = int.Parse(alterElem.Value);
                        note.Accidental = alterValue == 1 ? "#" : (alterValue == -1 ? "b" : "");
                    }
                    else
                    {
                        var accidentalElem = noteElem.Element(ns + "accidental");
                        if (accidentalElem != null)
                        {
                            string acc = accidentalElem.Value.ToLower();
                            note.Accidental = acc switch
                            {
                                "sharp" => "#",
                                "flat" => "b",
                                "natural" => "",
                                _ => ""
                            };
                        }
                    }
                }

                // Duration and Staff parsing (outside the IsRest check)
                note.Duration = double.Parse(noteElem.Element(ns + "duration")?.Value ?? "0");
                
                var staffElem = noteElem.Element(ns + "staff");
                note.Staff = staffElem != null ? int.Parse(staffElem.Value) : 1;
                note.IsChordWithPrevious = noteElem.Element(ns + "chord") != null;
                
                measure.Notes.Add(note);
            } // End of noteElem loop

            // 5. Add the complete measure to the score
            score.Measures.Add(measure);
        } // End of measureElem loop

        return score; 
    }
}