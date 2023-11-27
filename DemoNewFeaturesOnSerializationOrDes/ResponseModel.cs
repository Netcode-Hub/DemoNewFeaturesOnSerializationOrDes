using System.Text.Json.Serialization;

namespace DemoNewFeaturesOnSerializationOrDes
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public class ResponseModel
    {
        public DateOnly Date { get; set; }

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
