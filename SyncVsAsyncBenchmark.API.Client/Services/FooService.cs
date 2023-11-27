namespace SyncVsAsyncBenchmark.API.Client.Services
{
    public class FooService
    {
        private readonly HttpClient httpClient;
        private readonly string serverUrl;

        public FooService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            serverUrl = configuration["ServerHostUrl"];
        }

        public void GetSync()
        {
            try
            {
                var webRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverUrl}/foo");

                var response = httpClient.Send(webRequest);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetAsync()
        {
            try
            {
                var webRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverUrl}/foo");

                var response = await httpClient.SendAsync(webRequest);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
