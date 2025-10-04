// ================================================================
// W02 Project: Journal Program
// Author: Ngonidzaishe Chareka
// Description:
// A C# console journal application that lets the user write daily
// entries, displays them, and saves/loads them from a file.
//
// Creative Extensions:
// 1. Handles the "|" symbol safely in responses by joining remaining parts.
// 2. Adds an extra prompt.
// 3. Displays total entry count after loading.
// 4. Records and displays the date automatically.
//
// ================================================================

using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    // Member variables
    private string _prompt;
    private string _response;
    private string _date;

    // Constructor
    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    // Properties
    public string Prompt => _prompt;
    public string Response => _response;
    public string Date => _date;

    // Convert entry to string for saving
    public string ToSaveString()
    {
        // Use "|" as separator since it's rare in normal text
        return $"{_date}|{_prompt}|{_response}";
    }

    // Create Entry object from saved line
    public static Entry FromSaveString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length >= 3)
        {
            string date = parts[0];
            string prompt = parts[1];
            // Join remaining parts to avoid cutting off if user typed "|"
            string response = string.Join("|", parts, 2, parts.Length - 2);
            return new Entry(prompt, response, date);
        }
        else
        {
            return null;
        }
    }

    // For displaying the entry
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

// ================================================================

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _random = new Random();

        // List of prompts (at least 5, one extra added for creativity)
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn from today’s experiences?"
        };
    }

    // Write a new journal entry
    public void WriteEntry()
    {
        int idx = _random.Next(_prompts.Count);
        string prompt = _prompts[idx];

        Console.WriteLine("\n" + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry entry = new Entry(prompt, response, date);
        _entries.Add(entry);

        Console.WriteLine("✅ Entry recorded successfully!\n");
    }

    // Display all entries
    public void DisplayEntries()
    {
        Console.WriteLine("\n--- Journal Entries ---\n");

        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.\n");
        }
        else
        {
            foreach (Entry e in _entries)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    // Save entries to file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                writer.WriteLine(e.ToSaveString());
            }
        }

        Console.WriteLine($"💾 Journal saved successfully to '{filename}'.\n");
    }

    // Load entries from file
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"⚠️ File '{filename}' not found. Load aborted.\n");
            return;
        }

        List<Entry> loadedEntries = new List<Entry>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry e = Entry.FromSaveString(line);
            if (e != null)
            {
                loadedEntries.Add(e);
            }
        }

        _entries = loadedEntries;
        Console.WriteLine($"📂 Loaded { _entries.Count } entries from '{filename}'.\n");
    }
}

// ================================================================

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exitRequested = false;

        Console.WriteLine("======================================");
        Console.WriteLine("       JOURNAL PROGRAM - W02");
        Console.WriteLine("======================================\n");

        while (!exitRequested)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1–5): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter a filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter a filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    exitRequested = true;
                    Console.WriteLine("👋 Goodbye! Keep journaling every day!");
                    break;

                default:
                    Console.WriteLine("⚠️ Invalid choice. Please select between 1–5.\n");
                    break;
            }
        }
    }
}
