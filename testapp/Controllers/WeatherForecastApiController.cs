using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace testapp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastApiController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastApiController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecastApi")]
    public async Task<string> Get()
    {
    
        using var client = new HttpClient();
        var response =  await client.GetAsync(Environment.GetEnvironmentVariable("API_URL"));
        var content =   await response.Content.ReadAsStringAsync();
        return content.ToString();
    }
}
