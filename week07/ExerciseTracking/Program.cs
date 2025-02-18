using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    // Base class
    public abstract class Activity
    {
        // Private fields for encapsulation
        private DateTime _date;
        private double _durationInMinutes;

        // Constructor to initialize common properties
        public Activity(DateTime date, double durationInMinutes)
        {
            _date = date;
            _durationInMinutes = durationInMinutes;
        }

        // Public getter methods to access private fields
        public DateTime Date => _date;
        public double DurationInMinutes => _durationInMinutes;

        // Abstract methods to be overridden in derived classes
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Method to get a summary of the activity
        public string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {GetType().Name} ({DurationInMinutes} min) - Distance: {GetDistance():0.0} {GetDistanceUnit()}, Speed: {GetSpeed():0.0} {GetSpeedUnit()}, Pace: {GetPace():0.0} min per {GetPaceUnit()}";
        }

        // These methods are meant to be implemented in derived classes
        protected abstract string GetDistanceUnit();
        protected abstract string GetSpeedUnit();
        protected abstract string GetPaceUnit();
    }

    // Running class
    public class Running : Activity
    {
        private double _distanceInMiles;

        // Constructor for Running class
        public Running(DateTime date, double durationInMinutes, double distanceInMiles)
            : base(date, durationInMinutes)
        {
            _distanceInMiles = distanceInMiles;
        }

        // Get the distance for running
        public override double GetDistance()
        {
            return _distanceInMiles;
        }

        // Get the speed for running
        public override double GetSpeed()
        {
            return (_distanceInMiles / DurationInMinutes) * 60; // Speed in mph
        }

        // Get the pace for running
        public override double GetPace()
        {
            return DurationInMinutes / _distanceInMiles; // Pace in minutes per mile
        }

        protected override string GetDistanceUnit() => "miles";
        protected override string GetSpeedUnit() => "mph";
        protected override string GetPaceUnit() => "mile";
    }

    // Cycling class
    public class Cycling : Activity
    {
        private double _speedInKph;

        // Constructor for Cycling class
        public Cycling(DateTime date, double durationInMinutes, double speedInKph)
            : base(date, durationInMinutes)
        {
            _speedInKph = speedInKph;
        }

        // Get the distance for cycling
        public override double GetDistance()
        {
            return (_speedInKph * DurationInMinutes) / 60; // Distance in km
        }

        // Get the speed for cycling
        public override double GetSpeed()
        {
            return _speedInKph; // Speed in kph
        }

        // Get the pace for cycling
        public override double GetPace()
        {
            return 60 / _speedInKph; // Pace in minutes per km
        }

        protected override string GetDistanceUnit() => "km";
        protected override string GetSpeedUnit() => "kph";
        protected override string GetPaceUnit() => "km";
    }

    // Swimming class
    public class Swimming : Activity
    {
        private int _laps;

        // Constructor for Swimming class
        public Swimming(DateTime date, double durationInMinutes, int laps)
            : base(date, durationInMinutes)
        {
            _laps = laps;
        }

        // Get the distance for swimming
        public override double GetDistance()
        {
            return _laps * 50 / 1000.0; // Distance in km (50 meters per lap)
        }

        // Get the speed for swimming
        public override double GetSpeed()
        {
            return (GetDistance() / DurationInMinutes) * 60; // Speed in kph
        }

        // Get the pace for swimming
        public override double GetPace()
        {
            return DurationInMinutes / GetDistance(); // Pace in minutes per km
        }

        protected override string GetDistanceUnit() => "km";
        protected override string GetSpeedUnit() => "kph";
        protected override string GetPaceUnit() => "km";
    }

    // Main Program class
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of activities (Running, Cycling, Swimming)
            var activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0), // Running example
                new Cycling(new DateTime(2022, 11, 3), 30, 20.0), // Cycling example
                new Swimming(new DateTime(2022, 11, 3), 30, 20)  // Swimming example
            };

            // Iterate over activities and print summary for each
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
