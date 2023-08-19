using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace RealTimeUber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<WeatherForecastController> _localizer;
        public WeatherForecastController( IStringLocalizer<WeatherForecastController> localizerr)
        {
            _localizer = localizerr;
        }



        [HttpGet]
        public ActionResult<string> Get()
        {
            // Get the localized string based on the current culture
            var localizedString = _localizer["Welcome"].Value;

            return Ok(localizedString);
        }



    //    private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

        private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}