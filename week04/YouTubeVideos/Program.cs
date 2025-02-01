using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; } // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (var comment in comments)
        {
            Console.WriteLine($"  - {comment}");
        }

        Console.WriteLine(new string('-', 40)); // Separator
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("C# Basics", "Tech Guru", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can you cover more topics?"));

        Video video2 = new Video("Advanced C# Tips", "CodeMaster", 900);
        video2.AddComment(new Comment("David", "Mind-blowing techniques!"));
        video2.AddComment(new Comment("Eve", "Thanks for the insights."));
        video2.AddComment(new Comment("Frank", "This made my day!"));

        Video video3 = new Video("Design Patterns in C#", "Dev Ninja", 1200);
        video3.AddComment(new Comment("Grace", "I love the way you teach!"));
        video3.AddComment(new Comment("Hank", "Really informative."));
        video3.AddComment(new Comment("Ivy", "Looking forward to more videos!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
