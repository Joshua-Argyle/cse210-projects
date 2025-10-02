using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Musicnotes";
        job1._jobTitle = "Pianist";
        job1._startYear = "2023";
        job1._endYear = "2025";

        Job job2 = new Job();
        job2._company = "Nintendo";
        job2._jobTitle = "Game Tester";
        job2._startYear = "2019";
        job2._endYear = "2022";

        // job1.DisplayJobDetails();
        // job2.DisplayJobDetails();

        Resume myResume = new Resume();

        myResume._name = "Joshua Argyle";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.DisplayResume();
       

    }
}