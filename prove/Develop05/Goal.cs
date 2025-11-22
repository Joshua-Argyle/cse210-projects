public abstract class Goal
{
    protected string _status = "[ ]";
    protected int _points;
    protected string _goal;

    protected string _description;

    public Goal(string goal, string description, int points)
    {
        _goal = goal;
        _description = description;
        _points = points;
    }
    public string GetGoal()
    {
        return _goal;
    }
    public virtual string GetDescription()
    {
        return _description;
    }
    public virtual int GetPoints()
    {
        return _points;
    }
    public string GetStatus()
    {
        return _status;
    }
    public void RecordGoal()
    {
        
    }
    public void SetStatusComplete()
    {
        _status = "[X]";
    }
    public abstract void RecordEvent();
    public int GetPointsForSave()
    {
        return _points;
    }

}