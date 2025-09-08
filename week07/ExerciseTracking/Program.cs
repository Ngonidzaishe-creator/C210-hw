using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
    }
}


public abstract class Activity
{
    public string Date { get; set; }
    public int Minutes { get; set; }

    public Activity(string date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date} ({Minutes} min) - Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min/km";
    }
}

public class Running : Activity
{
    public double DistanceInKm { get; set; }

    public Running(string date, int minutes, double distanceInKm) : base(date, minutes)
    {
        DistanceInKm = distanceInKm;
    }

    public override double GetDistance()
    {
        return DistanceInKm;
    }

    public override double GetSpeed()
    {
        return (DistanceInKm / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / DistanceInKm;
    }
}

public class Cycling : Activity
{
    public double SpeedInKph { get; set; }

    public Cycling(string date, int minutes, double speedInKph) : base(date, minutes)
    {
        SpeedInKph = speedInKph;
    }

    public override double GetDistance()
    {
        return (SpeedInKph / 60) * Minutes;
    }

    public override double GetSpeed()
    {
        return SpeedInKph;
    }

    public override double GetPace()
    {
        return 60 / SpeedInKph;
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}

internal class Program
{
    private static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0 * 1.60934), // convert miles to km
            new Cycling("04 Nov 2022", 30, 20),
            new Swimming("05 Nov 2022", 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
