using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
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

        /// <summary>
        /// 獲取天氣預報的集合。
        /// </summary>
        /// <remarks>
        /// 此方法生成未來5天的天氣預報列表。
        /// 每個預報包含以下內容：
        /// - 從今天開始的日期，每個預報的日期遞增一天。
        /// - 隨機生成的攝氏溫度，範圍在 -20 到 55 之間。
        /// - 從預定義的摘要列表中隨機選擇的一個摘要。
        /// </remarks>
        /// <returns>
        /// 一個包含天氣預報的 <see cref="WeatherForecast"/> 對象數組。
        /// </returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("GetSummaries")]
        public ActionResult<IEnumerable<string>> GetSummaries()
        {
            return Ok(Summaries);
        }
    }
}
