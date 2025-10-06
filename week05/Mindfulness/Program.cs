using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine($"{_description}\n");
        Console.Write("Enter the duration of the activity in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            _duration = 30;
            Console.WriteLine("Invalid input. Defaulting to 30 seconds.\n");
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"Duration: {_duration} seconds.");
        Console.Write("Returning to the main menu");
        ShowSpinner(3);
    }

    public int GetDuration()
    {
        return _duration;
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity helps you relax by pacing your breathing.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountdown(4);
            Console.WriteLine("\n");
        }

        DisplayEndingMessage();
    }
}

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you helped someone in need.",
        "Recall a moment when you stood up for what was right.",
        "Remember a time when you accomplished something difficult.",
        "Think of a time you made someone smile."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel during this experience?",
        "What did you learn from it?",
        "How can you apply this lesson in your life?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity helps you reflect on times when you showed strength or kindness.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}\n");
        Console.WriteLine("Take a few seconds to think about this...");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"\n> {question} ");
            ShowSpinner(6);
        }

        DisplayEndingMessage();
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List people who make you happy.",
        "List things you are grateful for.",
        "List skills or talents you have.",
        "List memorable experiences from this week."
    };

    public ListingActivity()
        : base("Listing Activity", "This activity helps you list positive things in your life.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}\n");
        Console.WriteLine("Start listing items. Press Enter after each one.");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        DisplayEndingMessage();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Goodbye! Stay mindful.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}