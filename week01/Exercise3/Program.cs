using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter a positive number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Counting up to your number:");
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Now counting down:");
        for (int i = number; i >= 1; i--)
        {
            Console.WriteLine(i);
        }

        // Sum of all numbers from 1 to the entered number
        int sum = 0;
        for (int i = 1; i <= number; i++)
        {
            sum += i;
        }
        Console.WriteLine($"The sum of numbers from 1 to {number} is {sum}.");
    }
}
