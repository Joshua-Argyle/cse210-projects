public class JazzBallad : Accompaniment
{
    
public JazzBallad(List<List<string>> accompanimentData) : base(accompanimentData)
    {
        foreach (List<string> measure in accompanimentData)
        {
            for (int chord = 0; chord < measure.Count(); chord++)
            {
                string[] parts;
                parts = measure[chord].Split(':');
                string Value = parts[0].Trim();
                string importDuration = parts[1].Trim();
                int duration = int.Parse(importDuration);

                string[] partsValue;
                partsValue = Value.Split(" ");

                string rootStep = partsValue[0];
                string kind = partsValue[1];
                string third;

                for (int i = 0; i < 12; i++)
                {
                    if (keys[i] == rootStep)
                    {
                        if (kind == "minor")
                        {
                            third = $"{keys[i + 3]}";
                        }
                        else
                        {
                            third = $"{keys[i + 4]}";
                        }

                        string fifth = keys[i + 7];

                        string seventh = keys[i + 11];
                        string ninth = keys[i + 2];
                        if (duration == 8)
                        {
                            string body = $@"
      <note>
        <pitch>
          <step>{rootStep}</step>
          <alter>{AccidentalMaker(rootStep)}</alter>
          <octave>2</octave>
        </pitch>
        <duration>2</duration>
        <voice>2</voice>
        <type>eighth</type>
        <staff>2</staff>
      </note>

      <note>
      <chord/>
        <pitch>
          <step>{AccidentalParser(fifth)}</step>
          <alter>{AccidentalMaker(fifth)}</alter>
          <octave>2</octave>
        </pitch>
        <duration>2</duration>
        <voice>2</voice>
        <type>eighth</type>
        <staff>2</staff>
      </note>

      <note>
    
        <pitch>
          <step>{AccidentalParser(seventh)}</step>
          <alter>{AccidentalMaker(seventh)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
        <chord/>
        <pitch>
          <step>{AccidentalParser(ninth)}</step>
          <alter>{AccidentalMaker(ninth)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
      <chord/>
        <pitch>
          <step>{AccidentalParser(third)}</step>
          <alter>{AccidentalMaker(third)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>
        
      <note>
      <chord/>
        <pitch>
          <step>{fifth}</step>
          <alter>{AccidentalMaker(fifth)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
        <pitch>
          <step>{rootStep}</step>
          <alter>{AccidentalMaker(rootStep)}</alter>
          <octave>2</octave>
        </pitch>
        <duration>2</duration>
        <voice>2</voice>
        <type>eighth</type>
        <staff>2</staff>
      </note>

      <note>
      <chord/>
        <pitch>
          <step>{AccidentalParser(fifth)}</step>
          <alter>{AccidentalMaker(fifth)}</alter>
          <octave>2</octave>
        </pitch>
        <duration>2</duration>
        <voice>2</voice>
        <type>eighth</type>
        <staff>2</staff>
      </note>

      <note>
    
        <pitch>
          <step>{AccidentalParser(seventh)}</step>
          <alter>{AccidentalMaker(seventh)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
        <chord/>
        <pitch>
          <step>{AccidentalParser(ninth)}</step>
          <alter>{AccidentalMaker(ninth)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
      <chord/>
        <pitch>
          <step>{AccidentalParser(third)}</step>
          <alter>{AccidentalMaker(third)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>
        
      <note>
      <chord/>
        <pitch>
          <step>{fifth}</step>
          <alter>{AccidentalMaker(fifth)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>2</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>";

                            bodies.Add(body);
                        }

                        else
                        {
                            string body = $@"
            <note>
        <pitch>
          <step>{rootStep}</step>
          <alter>{AccidentalMaker(rootStep)}</alter>
          <octave>2</octave>
        </pitch>
        <duration>1</duration>
        <voice>2</voice>
        <type>eighth</type>
        <staff>2</staff>
      </note>

      <note>
      <chord/>
        <pitch>
          <step>{AccidentalParser(fifth)}</step>
          <alter>{AccidentalMaker(fifth)}</alter>
          <octave>2</octave>
        </pitch>
        <duration>1</duration>
        <voice>2</voice>
        <type>eighth</type>
        <staff>2</staff>
      </note>

      <note>
    
        <pitch>
          <step>{AccidentalParser(seventh)}</step>
          <alter>{AccidentalMaker(seventh)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>1</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
        <chord/>
        <pitch>
          <step>{AccidentalParser(ninth)}</step>
          <alter>{AccidentalMaker(ninth)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>1</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>

      <note>
      <chord/>
        <pitch>
          <step>{AccidentalParser(third)}</step>
          <alter>{AccidentalMaker(third)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>1</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>
        
      <note>
      <chord/>
        <pitch>
          <step>{fifth}</step>
          <alter>{AccidentalMaker(fifth)}</alter>
          <octave>4</octave>
        </pitch>
        <duration>1</duration>
        <voice>1</voice>
        <type>eighth</type>
        <staff>1</staff>
      </note>";

                            bodies.Add(body);
                        }
                    }
                }
            }
        }
    }

    
}