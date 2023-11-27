using Microsoft.AspNetCore.Mvc;

namespace SyncVsAsyncBenchmark.API.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly int SleepDuration;

        public FooController(IConfiguration configuration)
        {
            SleepDuration = Convert.ToInt32(configuration["SleepDuration"]);
        }

        [HttpGet]
        public async Task GetFoo()
        {
            await Task.Delay(SleepDuration);
        }
    }
}