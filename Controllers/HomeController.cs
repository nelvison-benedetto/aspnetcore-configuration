using Microsoft.AspNetCore.Mvc;

namespace _8_aspnetcore_configuration.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [Route("/")]
    public IActionResult Index()
    {
        //ViewBag.MyKey = _configuration["MyKey"];
        ViewBag.MyApiKey = _configuration.GetValue("MyApiKey","the default key");
        ViewBag.ClientID = _configuration["myweatherapi:ClientID"];
        ViewBag.ClientSecret = _configuration.GetValue("myweatherapi:ClientSecret","the default key");

        IConfigurationSection myWeatherApiSection = _configuration.GetSection("myweatherapi");
        ViewBag.ClientID = myWeatherApiSection["ClientID"];
        ViewBag.ClientSecret = myWeatherApiSection["ClientSecret"];

        return View();
    }
}
