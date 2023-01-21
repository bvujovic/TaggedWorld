namespace WebApiTaggedWorld.Data
{
    /// <summary>
    /// Test klasa koja sadrzi podatke za WeatherForecastControler.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>Datum</summary>
        public DateTime Date { get; set; }

        /// <summary>Temperatura u Celzijusovim stepenima.</summary>
        public int TemperatureC { get; set; }

        /// <summary>Temperatura u Farenhajtovim stepenima.</summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>Tip vremena: oblacno, suncano...</summary>
        public string? Summary { get; set; }
    }
}