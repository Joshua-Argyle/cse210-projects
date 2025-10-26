using System;

public class Appointment
{
    // Private fields (encapsulated)
    // Add private fields for title (string)and location (string)
    private string _title = "Unknown";
    private string _location = "TBD";

    // Add private fields for start (DateTime) and end (DateTime)
    private DateTime _start;
    private DateTime _end;

    // Constructors
    // Default constructor - using reasonable defaults
    public Appointment()
    {
        // Initialize fields with defaults
        _title = "Untitled";
        _location = "TBD";
        _start = DateTime.Now.AddHours(1); // 1 hour from now
        _end = _start.AddHours(1);         // 1 hour after start
    }

    // TODO: Parameterized constructor - accept title, start, end, location
    public Appointment(string title, string location, DateTime start, DateTime end)
    {
        // TIP: call Update methods so validation runs in one place
        UpdateTitle(title);
        UpdateLocation(location);
        UpdateTime(start, end);
    }

    // "Getter" methods
    // TODO: string GetTitle()
    public string GetTitle()
    {
        return _title;
    }
    // TODO: string GetLocation()
    public string GetLocation()
    {
        return _location;
    }
    // TODO: DateTime GetStart()
    public string GetStart()
    {
        return _start.ToString("MM/dd/yyyy hh:mm tt");
    }  

    // TODO: DateTime GetEnd()
    public string GetEnd()
    {
        return _end.ToString("MM/dd/yyyy hh:mm tt");
    }
    // TODO: string GetDetails()  // e.g., "Study Group — Sep 10 3:00 PM–4:00 PM @ Library"
    public string GetDetails()
    {
        string details = $"{GetTitle()} - {GetStart()}-{GetEnd()} @ {GetLocation()}";
        return details;
    }

    // "Setter" methods with simple validation. Each should return a bool (true if successful).
    // bool UpdateTitle(string title)  // non-empty
    public bool UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return false;
        }
        _title = title.Trim();
        return true;
    }
    // TODO: bool UpdateLocation(string location)  // allow "TBD" if empty
    public bool UpdateLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            return false;
        }
        _location = location.Trim();
        return true;
    }
    // TODO: bool UpdateTime(DateTime start, DateTime end)  // require end > start
    public bool UpdateTime(DateTime start, DateTime end)
    {
        _start = start;
        _end = end;
        return true; 
    }
}
