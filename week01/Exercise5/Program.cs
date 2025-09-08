using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
    }
}
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Number Calculation Menu ---");
            Console.WriteLine("1. Calculate Square and Cube");
            Console.WriteLine("2. Calculate Factorial");
            Console.WriteLine("3. Calculate Sum of Squares");
            Console.WriteLine("4. Calculate Product of Numbers");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CalculateSquareAndCube();
                        break;
                    case 2:
                        CalculateFactorial();
                        break;
                    case 3:
                        CalculateSumOfSquares();
                        break;
                    case 4:
                        CalculateProductOfNumbers();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    }

    static void CalculateSquareAndCube()
    {
        Console.Write("Enter a number to calculate its square and cube: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int square = Square(number);
            int cube = Cube(number);
            Console.WriteLine($"The square of {number} is {square}.");
            Console.WriteLine($"The cube of {number} is {cube}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void CalculateFactorial()
    {
        Console.Write("Enter a number to calculate its factorial: ");
        if (int.TryParse(Console.ReadLine(), out int factorialInput))
        {
            if (factorialInput < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
            }
            else
            {
                long factorialResult = Factorial(factorialInput);
                Console.WriteLine($"The factorial of {factorialInput} is {factorialResult}.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void CalculateSumOfSquares()
    {
        Console.Write("Enter the number of terms for sum of squares: ");
        if (int.TryParse(Console.ReadLine(), out int terms) && terms > 0)
        {
            long sum = 0;
            for (int i = 1; i <= terms; i++)
            {
                sum += Square(i);
            }
            Console.WriteLine($"The sum of squares of the first {terms} numbers is {sum}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static void CalculateProductOfNumbers()
    {
        Console.Write("Enter the number of terms for product calculation: ");
        if (int.TryParse(Console.ReadLine(), out int terms) && terms > 0)
        {
            long product = 1;
            for (int i = 1; i <= terms; i++)
            {
                product *= i;
            }
            Console.WriteLine($"The product of the first {terms} numbers is {product}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static int Square(int num)
    {
        return num * num;
    }

    static int Cube(int num)
    {
        return num * num * num;
    }

    static long Factorial(int num)
    {
        if (num == 0) return 1;
        long result = 1;
        for (int i = 1; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }
}
