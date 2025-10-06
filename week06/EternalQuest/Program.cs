using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");
    }
}

// ------------------- BASE CLASS -------------------
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();

    public string GetName() => _name;
    public bool IsComplete() => _isComplete;

    public virtual void MarkComplete()
    {
        _isComplete = true;
    }
}

// ------------------- SIMPLE GOAL -------------------
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Great job! You completed '{_name}' and earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine($"'{_name}' is already completed.");
            return 0;
        }
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}

// ------------------- ETERNAL GOAL -------------------
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"Progress recorded! You gained {_points} points for '{_name}'. Keep it up!");
        return _points;
    }

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}

// ------------------- CHECKLIST GOAL -------------------
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completedCount = 0;
    }

    public override int RecordEvent()
    {
        _completedCount++;
        int earnedPoints = _points;

        if (_completedCount >= _targetCount)
        {
            _isComplete = true;
            earnedPoints += _bonusPoints;
            Console.WriteLine($"Congratulations! You completed '{_name}' and earned a bonus of {_bonusPoints} points!");
        }
        else
        {
            Console.WriteLine($"Progress made! '{_name}' completed {_completedCount}/{_targetCount} times. +{_points} points.");
        }

        return earnedPoints;
    }

    public override string GetStatus()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} — Completed {_completedCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_bonusPoints}|{_completedCount}";
    }
}

// ------------------- GOAL MANAGER -------------------
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Display menu
    public void DisplayMenu()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine("\n===== Eternal Quest Menu =====");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score and Rank");
            Console.WriteLine("5. Save/Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": DisplayScoreAndRank(); break;
                case "5": SaveLoadMenu(); break;
                case "6": Console.WriteLine("Exiting program..."); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    // Create a new goal
    private void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    // List all goals
    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet!");
            return;
        }

        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetStatus()} - {goal.GetName()}");
            i++;
        }
    }

    // Record event for a goal
    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < _goals.Count)
        {
            _score += _goals[choice].RecordEvent();
        }
    }

    // Display score and rank
    private void DisplayScoreAndRank()
    {
        Console.WriteLine($"\nYour current score: {_score}");
        Console.WriteLine($"Rank: {GetRank()}");
    }

    private string GetRank()
    {
        if (_score < 500) return "Novice";
        if (_score < 1500) return "Apprentice";
        if (_score < 3000) return "Master";
        return "Legend";
    }

    // Save and Load
    private void SaveLoadMenu()
    {
        Console.WriteLine("1. Save Goals");
        Console.WriteLine("2. Load Goals");
        Console.Write("Enter choice: ");
        string option = Console.ReadLine();

        if (option == "1") SaveGoals();
        else if (option == "2") LoadGoals();
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved data found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) goal.MarkComplete();
                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[5]));
                for (int j = 0; j < int.Parse(parts[6]); j++)
                    goal.RecordEvent();
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}
