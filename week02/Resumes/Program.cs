using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
    }
    
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
    
        public Entry(string prompt, string response)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Prompt = prompt;
            Response = response;
        }
    
        public override string ToString()
        {
            return $"[{Date}] {Prompt}\n{Response}\n";
        }
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };


    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo journal entries yet.\n");
            return;
        }

        Console.WriteLine("\n📖 Your Journal Entries:\n");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
        Console.WriteLine();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine($"\n💾 Journal saved to {filename}\n");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry(parts[1], parts[2])
                    {
                        Date = parts[0]
                    };
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine($"\n📂 Journal loaded from {filename}\n");
        }
        else
        {
            Console.WriteLine("\n⚠️ File not found.\n");
        }
    }
}
