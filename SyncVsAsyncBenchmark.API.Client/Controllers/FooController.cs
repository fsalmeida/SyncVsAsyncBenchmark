using Microsoft.AspNetCore.Mvc;
using SyncVsAsyncBenchmark.API.Client.Services;

namespace SyncVsAsyncBenchmark.API.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly FooService fooService;

        public FooController(FooService fooService)
        {
            this.fooService = fooService;
        }

        [HttpGet]
        [Route("sync")]
        public async Task GetSync()
        {
            fooService.GetSync();
        }

        [HttpGet]
        [Route("async")]
        public async Task GetAsync()
        {
            await fooService.GetAsync();
        }
    }
}
