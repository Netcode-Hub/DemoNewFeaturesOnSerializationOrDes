using System.Text.Json.Serialization;

namespace DemoNewFeaturesOnSerializationOrDes
{
    public class WeatherForecast1
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(WeatherForecast1))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {

    }
}
