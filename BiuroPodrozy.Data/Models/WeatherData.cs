namespace BiuroPodrozy.Data.Models
{
    public class WeatherData
    {
        public Coordinates Coord { get; set; } // Coordinates (longitude, latitude)
        public List<WeatherDescription> Weather { get; set; } // Weather descriptions
        public string Base { get; set; } // Internal parameter
        public MainWeather Main { get; set; } // Main weather information
        public int Visibility { get; set; } // Visibility in meters
        public Wind Wind { get; set; } // Wind information
        public Rain Rain { get; set; } // Rain information (optional)
        public Clouds Clouds { get; set; } // Cloud cover information
        public long Dt { get; set; } // Unix timestamp of the data
        public Sys Sys { get; set; } // System information
        public int Timezone { get; set; } // Timezone offset in seconds
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; } // HTTP status code (200 indicates success)
    }

    public class Coordinates
    {
        public double Lon { get; set; } // Longitude
        public double Lat { get; set; } // Latitude
    }

    public class WeatherDescription
    {
        public int Id { get; set; } // Weather condition ID
        public string Main { get; set; } // Main weather condition (e.g., "Rain", "Clear")
        public string Description { get; set; } // Detailed weather description
        public string Icon { get; set; } // Weather icon code (optional)
    }

    public class MainWeather
    {
        public double Temp { get; set; } // Temperature in Kelvin
        public double FeelsLike { get; set; } // Feels-like temperature in Kelvin
        public double TempMin { get; set; } // Minimum temperature in Kelvin
        public double TempMax { get; set; } // Maximum temperature in Kelvin
        public int Pressure { get; set; } // Atmospheric pressure (hPa)
        public int Humidity { get; set; } // Humidity percentage
        public int SeaLevel { get; set; } // Sea level pressure (hPa)
        public int GrndLevel { get; set; } // Ground level pressure (hPa)
    }

    public class Wind
    {
        public double Speed { get; set; } // Wind speed in m/s
        public int Deg { get; set; } // Wind direction in degrees
        public double Gust { get; set; } // Wind gust speed in m/s (optional)
    }

    public class Rain
    {
        public double OneHour { get; set; } // Rainfall amount in the last hour (optional)
    }

    public class Clouds
    {
        public int All { get; set; } // Percentage of cloud cover
    }

    public class Sys
    {
        public int Type { get; set; } // Internal parameter
        public int Id { get; set; } // Internal parameter

        public string Country { get; set; } // Country code
        public long Sunrise { get; set; } // Sunrise time in Unix timestamp
        public long Sunset { get; set; } // Sunset time in Unix timestamp
    }
}