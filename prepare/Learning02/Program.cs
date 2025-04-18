using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Documentation Team Lead";
        job1._company = "BYU-Idaho";
        job1._startYear = 2020;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Helpdesk Tech";
        job2._company = "StrongMind";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Josh McMullens";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}