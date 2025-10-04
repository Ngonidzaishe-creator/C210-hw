public class Entry
{
    // Add properties and methods as needed
    public static Entry FromSaveString(string line)
    {
        // Implement parsing logic here
        return new Entry();
    }

    public string ToSaveString()
    {
        // Implement serialization logic here
        return "";
    }
}

public class ResumeManager
{
    private List<Entry> _entries = new List<Entry>();

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToSaveString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear(); // remove old entries
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromSaveString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
    }
}
