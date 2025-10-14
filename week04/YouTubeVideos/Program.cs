using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($" - {comment.GetCommenterName()}: {comment.GetCommentText()}");
        }
        Console.WriteLine();
    }
}
public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _name;
    }

    public string GetCommentText()
    {
        return _text;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));

        Video video2 = new Video("Learn Python", "Jane Smith", 800);
        video2.AddComment(new Comment("Charlie", "I love Python!"));
        video2.AddComment(new Comment("Dave", "This was a bit fast-paced."));
        video2.AddComment(new Comment("Eve", "Can you make a follow-up video?"));

        // Display video information
            video1.DisplayVideoInfo();
            video2.DisplayVideoInfo();
        }
    }