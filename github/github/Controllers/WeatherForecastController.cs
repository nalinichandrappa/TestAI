using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.IO;
using System.IO.Compression;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace github.Controllers
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
        public readonly HttpClient _gitHttpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            
            _logger = logger;
            
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public  IEnumerable<WeatherForecast> Get()
        {

            var testhtto = Mainhttp();
            //var testocto = Main();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {

                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        public static async Task Mainhttp()
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {personalAccessToken}");
                //client.DefaultRequestHeaders.Add("Cookie", cookie);
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClient");
                HttpResponseMessage response = await client.GetAsync(new Uri ("https://api.github.com/user"));

                string jsonResponse = await response.Content.ReadAsStringAsync();

            }

        }

         
    }

    }
