using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoNewFeaturesOnSerializationOrDes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast1> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast1
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Fake")]
        public async Task<IActionResult> GetWeatherForecast2()
        {
            //var result = Get().FirstOrDefault();
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
            //};
            //// 4 properties
            ////Serializing
            //var serializeObj = JsonSerializer.Serialize(result, options);

            ////Deserializing
            //var deserializeObj = JsonSerializer.Deserialize<WeatherForecast>(serializeObj, options);
            //Console.WriteLine(serializeObj);
            //return Ok(serializeObj);


            // JsonTypeInfo<T> 
            //var result = Get().FirstOrDefault();
            //string jsonObj = JsonSerializer.Serialize(result, SourceGenerationContext.Default.WeatherForecast1!);
            //Console.WriteLine(jsonObj);
            //return Ok(jsonObj);

            //JsonSerializerContext:
            //var result = Get().FirstOrDefault();
            //string jsonObj = JsonSerializer.Serialize(result, typeof(WeatherForecast1), SourceGenerationContext.Default!);
            //Console.WriteLine(jsonObj);
            //return Ok(jsonObj);


            //JsonSerializerOptions:
            var result = Get().FirstOrDefault();
            var sourceGenerationOptions = new JsonSerializerOptions
            {
                TypeInfoResolver = SourceGenerationContext.Default
            };
            string jsonObj = JsonSerializer.Serialize(result, typeof(WeatherForecast1), sourceGenerationOptions);




            //Deserialization
            // JsonTypeInfo<T>
            //var weatherForecastData = JsonSerializer.Deserialize<WeatherForecast1>(jsonObj,
            //    SourceGenerationContext.Default.WeatherForecast1);


            // JsonSerializerContext:
            //var weatherForecastData = JsonSerializer.Deserialize(jsonObj,
            //    typeof(WeatherForecast1), SourceGenerationContext.Default) as WeatherForecast1;



            //JsonSerializerOptions:
            var result1 = JsonSerializer.Deserialize(jsonObj, typeof(WeatherForecast1), sourceGenerationOptions);
            return Ok(result1);
        }
    }
}
