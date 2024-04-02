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
            var personalAccessToken = "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";
            var cookie = "_octo=GH1.1.1515798275.1711541490; logged_in=no";

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


        //static async Task Main()
        //{
        //    string personalAccessToken = "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"; // Replace this with your actual PAT
        //    string repositoryOwner = "nalinichandrappa"; // Replace with the repository owner's username or organization name
        //    string repositoryName = "nalinichandrappa"; // Replace with the repository name
        //    string filePath = "";
        //    // Create credentials using Personal Access Token
        //    var credentials = new Credentials(personalAccessToken);

        //    // Create Octokit GitHubClient with the credentials
        //    var client = new GitHubClient(new ProductHeaderValue("TestAI"));
        //    client.Credentials = credentials;

        //    try
        //    {
        //        // Example: Get current authenticated user
        //        var user = await client.User.Current();
        //        Console.WriteLine($"Authenticated User: {user.Login}");
        //        var repositories = await client.Repository.GetAllForCurrent();
        //        Console.WriteLine($"Repository User:");
        //        var filepath = $"https://api.github.com/repos/{repositoryOwner}/{repositoryName}/contents/path";

        //        //using (HttpClient _gitHttpClient = new HttpClient())
        //        //{
        //        //    // client.DefaultRequestHeaders.Add("Private-Token", personalAccessToken);
        //        //    HttpResponseMessage response = await _gitHttpClient.GetAsync(filepath);
        //        //    string jsonResponse = await response.Content.ReadAsStringAsync();

        //        //    //await FetchFilesRecursive(client, apiUrl);
        //        //}

        //        var repositoriespriv = await client.Repository.GetAllForCurrent(new RepositoryRequest
        //        {
        //            Visibility = RepositoryRequestVisibility.All
        //        }); ;

        //        var fileContent = await client.Repository.Content.GetAllContentsByRef(repositoryOwner, repositoryName, filePath);

        //        if (fileContent.Count > 0)
        //        {
        //            var content = fileContent[0].Content; // Assuming the file is not a directory and has content
        //            Console.WriteLine("File Content:");
        //            Console.WriteLine(content);
        //        }
        //        else
        //        {
        //            Console.WriteLine("File not found or empty.");
        //        }

        //        Console.WriteLine($"privaterepo:");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}


    }

    // Class to represent a GitLab file
    public class GitLabFile
    {
        public string path { get; set; }
        public string type { get; set; }
        public string content { get; set; }
    }

    public class FileDetails
    {
        public string contents { get; set; } = string.Empty;
    }
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class FileMetadata
    {
        public string Path { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

    }
    public class FileDetail
    {
        public string File_Name { get; set; } = string.Empty;
        public string File_Path { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class CodeFile
    {
        public string Path { get; set; }    
        public string content { get; set; }    
    }
}
