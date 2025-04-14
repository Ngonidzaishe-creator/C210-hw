using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
    }


using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            MindfulnessApp app = new MindfulnessApp();
            app.Start();
        }
    }

    public class MindfulnessApp
    {
        private List<Activity> activities;

        public MindfulnessApp()
        {
            activities = new List<Activity>
            {
                new BreathingActivity(),
                new ReflectionActivity(),
                new ListingActivity()
            };
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program!");
                Console.WriteLine("Please choose an activity:");
                for (int i = 0; i < activities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {activities[i].GetName()}");
                }
                Console.WriteLine("4. Exit");
                int choice = GetUserChoice(1, 4);
                if (choice == 4) break;
                Activity selectedActivity = activities[choice - 1];
                selectedActivity.StartActivity();
            }
        }

        private int GetUserChoice(int min, int max)
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.WriteLine($"Please enter a number between {min} and {max}:");
            }
            return choice;
        }
    }

    public abstract class Activity
    {
        protected int duration;

        public abstract string GetName();
        public abstract string GetDescription();

        public void StartActivity()
        {
            Console.Clear();
            Console.WriteLine(GetName());
            Console.WriteLine(GetDescription());
            Console.Write("Enter the duration in seconds: ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready...");
            Pause(3);
            ExecuteActivity();
            Console.WriteLine("Good job! You completed the activity.");
            Console.WriteLine($"Duration: {duration} seconds.");
            Pause(3);
        }

        protected void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\rPausing for {i} seconds... ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write("/-\\|".ToCharArray()[i % 4]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\rCountdown: {i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected abstract void ExecuteActivity();
    }

    public class BreathingActivity : Activity
    {
        public override string GetName() => "Breathing Activity";
        public override string GetDescription() => "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

        protected override void ExecuteActivity()
        {
            int breathDuration = 4;
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                Breathe("Breathe in...", breathDuration);
                Breathe("Breathe out...", breathDuration);
            }
        }

        private void Breathe(string direction, int pauseTime)
        {
            Console.WriteLine(direction);
            Countdown(pauseTime);
        }
    }

    public class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public override string GetName() => "Reflection Activity";
        public override string GetDescription() => "This activity will help you reflect on times in your life
