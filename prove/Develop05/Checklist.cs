public class Checklist : Goal
{
    private int _checklistCount;
    private int _bonusPoints;
    private int _completedTimes = 0;
    private string _checklistDescription;
   public Checklist(string goal, string description, int points, int bonusPoints, int completedCount, int checklistCount) : base (goal, description, points){
    
        _bonusPoints = bonusPoints;
        _checklistCount = checklistCount;
        _completedTimes = completedCount;
    }
    public override void RecordEvent()
    {
        if (_completedTimes >= _checklistCount)

            _status = "[X]";

        else
        {
            _status = "[ ]";
        }


        
    }
    public override string GetDescription()
    {
        _checklistDescription = $"{_description} -- Currently completed: {_completedTimes}/{_checklistCount}";
        return _checklistDescription;
    }
    public string GetSavedDescription()
    {
        return _description;
    }
    public override int GetPoints()
    {
        _completedTimes += 1;
        if (_completedTimes == _checklistCount) {
            Console.WriteLine($"Congrats, you completed this goal and recieved an additional {_bonusPoints}");
            Console.WriteLine();
            return _points + _bonusPoints;
        }
        else if (_completedTimes < _checklistCount)
        {
            return _points;
        }
        else
        {
            Console.WriteLine("You recorded a goal that has already been completed, awarded points will be 0.");
            return 0;
        }
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public int GetCompletedTimes()
    {
        return _completedTimes;
    }
    public int GetChecklistCount()
    {
        return _checklistCount;
    }
}