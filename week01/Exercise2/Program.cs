using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter your score (0-100): ");
        int score = int.Parse(Console.ReadLine());

        if (score >= 90)
        {
            Console.WriteLine("You received an A!");
        }
        else if (score >= 80)
        {
            Console.WriteLine("You received a B!");
        }
        else if (score >= 70)
        {
            Console.WriteLine("You received a C!");
        }
        else if (score >= 60)
        {
            Console.WriteLine("You received a D!");
        }
        else
        {
            Console.WriteLine("You received an F.");
        }

        // Additional feedback
        if (score >= 60)
        {
            Console.WriteLine("Congratulations! You passed.");
        }
        else
        {
            Console.WriteLine("Don't worry, you can try again!");
        }
    }
}