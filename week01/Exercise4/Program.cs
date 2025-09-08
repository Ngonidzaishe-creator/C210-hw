using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
    }
}
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> fruits = new List<string>();
        string input;

        Console.WriteLine("Enter fruits (type 'done' to finish):");
        while (true)
        {
            input = Console.ReadLine();
            if (input.ToLower() == "done")
                break;
            fruits.Add(input);
        }

        Console.WriteLine("You entered the following fruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Additional functionality: Sorting the list
        fruits.Sort();
        Console.WriteLine("Fruits in alphabetical order:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }
}
