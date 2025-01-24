using System;
using System.Collections.Generic; // Required for using List

public class Job
{
    public string _jobTitle; // Job title
    public string _company;  // Company name
    public int _startYear;   // Start year
    public int _endYear;     // End year

    // Method to display job details
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume
{
    public string _name; // Resume owner's name
    public List<Job> _jobs = new List<Job>(); // List of jobs

    // Method to display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display(); // Call the Display method of each job
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creating Job objects
        Job job1 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Microsoft",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job
        {
            _jobTitle = "Manager",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        // Creating Resume object and adding jobs
        Resume resume = new Resume
        {
            _name = "Allison Rose"
        };
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // Displaying the resume
        resume.Display();
    }
}
