using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    }
}using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create video instances
        Video video1 = new Video("Learning C#", "President Thomas S. Monson", 300);
        video1.AddComment(new Comment("President Thomas S. Monson", "Be Strong and of a Good Courage"));
        
        Video video2 = new Video("Understanding Polymorphism", "Jane Smith", 450);
        video2.AddComment(new Comment("Charlie", "This clarified a lot for me."));
        video2.AddComment(new Comment("David", "Awesome explanation!"));
        
        Video video3 = new Video("Introduction to Data Structures", "Emily Johnson", 600);
        video3.AddComment(new Comment("Eve", "I love this content!"));
        video3.AddComment(new Comment("Frank", "Can you make a follow-up video?"));

        // Add videos to a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
