public class LeadSheetGenerator
{
    private List<List<string>> _accompanimentData = new List<List<string>>();
    protected List<string> bodies = new List<string>();
    public LeadSheetGenerator(List<List<string>> accompanimentData)
    {
        _accompanimentData = accompanimentData;
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
                string body = $@"
    <harmony>
        <root>
            <root-step>{rootStep}</root-step>
        </root>
        <kind>{kind.ToLower()}</kind>
    </harmony>
    
    <note>
        <rest/>
        <duration>{duration}</duration>
    </note>";
                bodies.Add(body);
            }


        }
        
}
public List<string> RythmnMaker()
    {
        return bodies;
    }
}