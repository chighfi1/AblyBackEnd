using IO.Ably;
using Microsoft.AspNetCore.Mvc;

namespace AblyBackEnd.Controllers
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

        [HttpPost(Name = "new message")]
        public async Task IActionResultAsync([FromBody] string messageText)
        {

            var clientOptions = new ClientOptions("QE5f4w.GDC4vQ:8iYNQgw7acoIARIMKGJ8WAI5fFzwmkoNbRVQBP4Wpmk");
            var ably = new AblyRealtime(clientOptions);
            var channel = ably.Channels.Get("blobtastic");
            channel.Presence.Enter("Red");

            var result = await channel.PublishAsync("greeting", messageText);
        }

        [HttpGet(Name = "GetToken")]
        public IActionResult Get()
        {
            var ably = new AblyRest("QE5f4w.GDC4vQ:8iYNQgw7acoIARIMKGJ8WAI5fFzwmkoNbRVQBP4Wpmk");
            var tokenDetails = ably.Auth.RequestToken();
            return Ok(new { token = tokenDetails });
        }
            
    }
}