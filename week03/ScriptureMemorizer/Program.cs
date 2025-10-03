using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: multiple scriptures stored in a list
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart, and do not lean on your own understanding. In all your ways acknowledge him, and he will make straight your paths.")
        };

        Random rnd = new Random();
        Scripture selectedScripture = scriptures[rnd.Next(scriptures.Count)];

        bool running = true;

        while (running)
        {
            Console.Clear();
            selectedScripture.Display();

            if (selectedScripture.AllHidden())
            {
                Console.WriteLine("All words are hidden. Great job memorizing!");
                break;
            }

            Console.WriteLine("Press ENTER to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                running = false;
            }
            else
            {
                selectedScripture.HideRandomWords();
            }
        }
    }
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        foreach (var word in _words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine("\n");
    }

    // Hide a few random words that are not yet hidden
    public void HideRandomWords(int count = 3)
    {
        var notHidden = _words.Where(w => !w.IsHidden).ToList();

        if (notHidden.Count == 0)
            return;

        for (int i = 0; i < count; i++)
        {
            if (notHidden.Count == 0)
                break;

            var wordToHide = notHidden[_random.Next(notHidden.Count)];
            wordToHide.Hide();
            notHidden.Remove(wordToHide);
        }
    }

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}

public class Reference
{
    public string Book { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    // Single verse constructor
    public Reference(string book, int verse)
    {
        Book = book;
        StartVerse = verse;
        EndVerse = null;
    }

    // Verse range constructor
    public Reference(string book, int startVerse, int endVerse)
    {
        Book = book;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
            return $"{Book} {StartVerse}-{EndVerse}";
        else
            return $"{Book} {StartVerse}";
    }
}
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public string Display()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }
}
