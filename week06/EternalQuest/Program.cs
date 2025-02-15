using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(ref int score);
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent(ref int score)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            score += _points;
        }
    }

    public override bool IsComplete() => _isComplete;
    public override string GetDetailsString() => _isComplete ? "[X] " + _shortName : "[ ] " + _shortName;
    public override string GetStringRepresentation() => $"SimpleGoal,{_shortName},{_description},{_points},{_isComplete}";
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent(ref int score)
    {
        score += _points;
    }

    public override bool IsComplete() => false;
    public override string GetDetailsString() => "[∞] " + _shortName;
    public override string GetStringRepresentation() => $"EternalGoal,{_shortName},{_description},{_points}";
}

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent(ref int score)
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            score += _points;
            if (_amountCompleted == _target)
                score += _bonus;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;
    public override string GetDetailsString() => $"[✓] {_shortName} ({_amountCompleted}/{_target})";
    public override string GetStringRepresentation() => $"ChecklistGoal,{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
}

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void ListGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal type (simple, eternal, checklist): ");
        string type = Console.ReadLine().ToLower();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "simple")
            _goals.Add(new SimpleGoal(name, description, points));
        else if (type == "eternal")
            _goals.Add(new EternalGoal(name, description, points));
        else if (type == "checklist")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.Write("Enter goal name to record: ");
        string name = Console.ReadLine();
        foreach (var goal in _goals)
        {
            if (goal.GetDetailsString().Contains(name))
            {
                goal.RecordEvent(ref _score);
                Console.WriteLine("Event recorded!");
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }

    public void SaveGoals()
    {
        using (StreamWriter file = new StreamWriter("goals.txt"))
        {
            file.WriteLine(_score);
            foreach (var goal in _goals)
                file.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            _goals.Clear();
            using (StreamReader file = new StreamReader("goals.txt"))
            {
                _score = int.Parse(file.ReadLine());
                while (!file.EndOfStream)
                {
                    string[] parts = file.ReadLine().Split(',');
                    if (parts[0] == "SimpleGoal")
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                    else if (parts[0] == "EternalGoal")
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    else if (parts[0] == "ChecklistGoal")
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Display Player Info\n2. List Goals\n3. Create Goal\n4. Record Event\n5. Save Goals\n6. Load Goals\n7. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: manager.DisplayPlayerInfo(); break;
                case 2: manager.ListGoals(); break;
                case 3: manager.CreateGoal(); break;
                case 4: manager.RecordEvent(); break;
                case 5: manager.SaveGoals(); break;
                case 6: manager.LoadGoals(); break;
                case 7: running = false; break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }
}
