public class Simple : Goal
{
   public Simple(string goal, string description, int points) : base (goal, description, points){}
    public override void RecordEvent()
    {
        _status = "[X]";
        
    }
    public override int GetPoints()
    {
        if (_status == "[ ]")
            return _points;
        else
        {
            Console.WriteLine("You recorded a goal that has already been completed, awarded points will be 0.");
            return 0;
        }
    }
    
}