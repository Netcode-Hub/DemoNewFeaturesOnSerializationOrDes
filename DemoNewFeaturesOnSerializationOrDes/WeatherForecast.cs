using System.Text.Json.Serialization;

namespace DemoNewFeaturesOnSerializationOrDes
{
    public class WeatherForecast
    {
        [JsonConstructor]
        internal WeatherForecast()
        {
            Total = TemperatureC + TemperatureF;
        }


        [JsonInclude]
        internal DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        [JsonInclude]
        internal int Total { get; set; }
    }
}
