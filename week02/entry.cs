using System;

public class Entry
{
    // ---------------------------
    // Member Variables
    // ---------------------------
    private string _prompt;
    private string _response;
    private string _date;

    // ---------------------------
    // Constructor
    // ---------------------------
    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    // ---------------------------
    // Properties (read-only)
    // ---------------------------
    public string Prompt
    {
        get { return _prompt; }
    }

    public string Response
    {
        get { return _response; }
    }

    public string Date
    {
        get { return _date; }
    }

    // ---------------------------
    // Method: Convert entry to save format
    // ---------------------------
    public string ToSaveString()
    {
        // Use "|" as separator to avoid common text conflicts
        return $"{_date}|{_prompt}|{_response}";
    }

    // ---------------------------
    // Method: Create Entry from a saved file line
    // ---------------------------
    public static Entry FromSaveString(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length >= 3)
        {
            string date = parts[0];
            string prompt = parts[1];
            // Join remaining parts in case user typed "|" in response
            string response = string.Join("|", parts, 2, parts.Length - 2);

            return new Entry(prompt, response, date);
        }
        else
        {
            // Invalid data line
            return null;
        }
    }

    // ---------------------------
    // Method: Display entry content
    // ---------------------------
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
