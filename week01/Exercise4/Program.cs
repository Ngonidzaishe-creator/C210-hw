using System;

internal class Program
{
    private static void Main();
class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
                numbers.Add(input);
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch 1: Find smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch 2: Sort and display list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
