using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;

namespace Caching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        // [ResponseCache(Duration = 60)]
        // [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        // [HttpCacheValidation(MustRevalidate = false)]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
                var entities = _context.WeatherForecasts.ToArray();
            return Ok(entities);
        }
    }
}
