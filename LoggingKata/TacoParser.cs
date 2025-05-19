using System;

namespace LoggingKata
{

    /// Parses a POI file to locate all the Taco Bells
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Splits into an array of strings:
            var cells = line.Split(',');

            // Checks if array's Length is less than 3:
            if (cells.Length < 3)
            {
                // Logs error message and return null
                logger.LogError("file was incomplete", null);
                return null; 
            }
            
            // Grabs latitude from array:
            var latitude = double.Parse(cells[0]);
            
            
            // Grabs longitude from array:
            var longitude = double.Parse(cells[1]);
            
            
            // Grabs name from array:
            var name = cells[2];
            
            
            logger.LogInfo($"Setting location - Latitude: {latitude}, Longitude: {longitude}");
            var point = new Point();
            
            point.Latitude = latitude;
            point.Longitude = longitude;

            
            logger.LogInfo($"Finding TacoBell...");
            var tacoBell = new TacoBell();
            
            tacoBell.Name = name;
            tacoBell.Location = point;


            return tacoBell;

            
        }
    }
}
