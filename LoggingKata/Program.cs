using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Finds the two Taco Bells that are the farthest apart from one another.

            logger.LogInfo("Log initialized");

            // Uses File.ReadAllLines(path) to grab all the lines from csv file. 
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("Something went wrong. No records found.");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("Something went wrong. Records incomplete.");
            }

            // This will display the first item in array
            logger.LogInfo($"Lines: {lines[0]}");

            // Creates a new instance of TacoParser class
            var parser = new TacoParser();

            // Uses the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();

            
            // Stores the two Taco Bells that are the farthest from each other.
            ITrackable location1 = null;
            ITrackable location2 = null;


            double distance = 0;

            // This loop selects one location at a time to act as the "starting point" or "origin" location.
            logger.LogInfo("Analyzing distance between each TacoBell location.");

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                

                // This picks a "destination" location for each "origin" location from the first loop. 
  
                for (int j = i + 1; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                 
                    // Updates the currently saved distance, if the distance is greater
                    var currentDistance = corA.GetDistanceTo(corB);
                    if (currentDistance > distance)
                    {
                        distance = currentDistance;
                        location1 = locA;
                        location2 = locB;
                    }
                }
            }
            
            // foreach (var locA in locations)
            // {
            //     var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
            //
            //     foreach (var locB in locations)
            //     {
            //         var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
            //
            //         if (corA.GetDistanceTo(corB) > distance)
            //         {
            //             distance = corA.GetDistanceTo(corB);
            //             location1 = locA;
            //             location2 = locB;
            //         }
            //     }
            // }
            

            // Displays two Taco Bell locations that are farthest apart to the console.
            var distanceKM = distance / 1000;
            var distanceMiles = distanceKM * 1.609344;
            
            logger.LogInfo("Analyzing complete.");
            logger.LogInfo($"The two TacoBells furthest apart are: {location1.Name}, {location2.Name}");
            logger.LogInfo($"Their coordinates are: {location1.Location.Latitude}, {location1.Location.Longitude}, {location2.Location.Latitude}, and {location2.Location.Longitude} {location2.Location.Latitude}");
            logger.LogInfo($"The distance is: {distanceKM} kilometers or {distanceMiles} miles.");

        }
    }
}






        



    


    

