using System;
using System.Collections.Generic;

public abstract class Activity
{
    // Encapsulation: Private member variables
    private DateTime _date;
    private int _lengthInMinutes;

    // Constructor
    protected Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Getters
    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    // Abstract methods for polymorphism (must be overridden)
    public abstract double GetDistance(); // in km
    public abstract double GetSpeed();    // in kph
    public abstract double GetPace();     // minutes per km

    // Virtual method: available to all derived classes
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}

public class Running : Activity
{
    private double _distance; // in km

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}

public class Cycling : Activity
{
    private double _speed; // in kph

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Each lap = 50 meters, convert to km
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity type
        Running run = new Running(new DateTime(2022, 11, 3), 30, 4.8);
        Cycling cycle = new Cycling(new DateTime(2022, 11, 3), 40, 20);
        Swimming swim = new Swimming(new DateTime(2022, 11, 3), 25, 30);

        // Store all in one list (Polymorphism in action)
        List<Activity> activities = new List<Activity> { run, cycle, swim };

        // Display each summary
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
