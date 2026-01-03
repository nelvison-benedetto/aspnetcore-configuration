using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace _8_aspnetcore_configuration.Controllers;

public class HomeController : Controller
{
    //private readonly IConfiguration _configuration;
    private readonly WeatherApiOptions _options;

    //public HomeController(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}
    public HomeController(IOptions<WeatherApiOptions> weatherapioptions)
    {
        _options = weatherapioptions.Value;
    }

    [Route("/")]
    public IActionResult Index()
    {
        //ViewBag.MyKey = _configuration["MyKey"];
        //ViewBag.MyApiKey = _configuration.GetValue("MyApiKey","the default key");
        //ViewBag.ClientID = _configuration["myweatherapi:ClientID"];
        //ViewBag.ClientSecret = _configuration.GetValue("myweatherapi:ClientSecret","the default key");

        //IConfigurationSection myWeatherApiSection = _configuration.GetSection("myweatherapi");
        //ViewBag.ClientID = myWeatherApiSection["ClientID"];
        //ViewBag.ClientSecret = myWeatherApiSection["ClientSecret"];

        //bind: creates and loads config values into a new Options object
        //WeatherApiOptions options = _configuration.GetSection("myweatherapi").Get<WeatherApiOptions>();

        //bind: loads config values into an existing Options object
        //WeatherApiOptions options = new WeatherApiOptions(); _configuration.GetSection("myweatherapi").Bind(options);
        //ViewBag.ClientID = options.ClientID;
        //ViewBag.ClientSecret = options.ClientSecret;

        ViewBag.ClientID = _options.ClientID;
        ViewBag.ClientSecret = _options.ClientSecret;

        return View();
    }
}
