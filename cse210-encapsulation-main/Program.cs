using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("Student Appointment Program\n");

        // 1. Create a student using the parameterized constructor
        Student s1 = new Student("Emma", "Johnson", "emma.johnson@byui.edu");
        Console.WriteLine("Created Student:");
        Console.WriteLine($"Name: {s1.GetFullName()}");
        Console.WriteLine($"Email: {s1.GetEmail()}");
        Console.WriteLine();

        // 2. Create a few appointments
        Appointment study = new Appointment();
        study.UpdateTitle("CSE 110 Study Group");
        study.UpdateLocation("Library Study Room 203");
        DateTime studyStart = DateTime.Now.AddHours(2);
        DateTime studyEnd = studyStart.AddHours(1);
        study.UpdateTime(studyStart, studyEnd);

        Appointment devotional = new Appointment(
            "Devotional",
            "BYU-I Center",
            DateTime.Now.AddDays(1).AddHours(11),
            DateTime.Now.AddDays(1).AddHours(12)
        );

        Appointment work = new Appointment(
            "On-Campus Job Shift",
            "IT Help Desk",
            DateTime.Now.AddDays(1).AddHours(14),
            DateTime.Now.AddDays(1).AddHours(17)
        );

        // 3. Add appointments to the student
        s1.AddAppointment(study);
        s1.AddAppointment(devotional);
        s1.AddAppointment(work);

        // 4. Print schedule
        Console.WriteLine("Current Schedule:");
        Console.WriteLine(s1.GetScheduleSummary());
        Console.WriteLine();

    }
}

