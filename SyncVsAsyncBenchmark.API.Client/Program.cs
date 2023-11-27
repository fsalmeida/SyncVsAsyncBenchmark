using SyncVsAsyncBenchmark.API.Client.Services;

namespace SyncVsAsyncBenchmark.API.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var threadPoolMinThreadsConfig = builder.Configuration["ThreadPoolMinThreads"];
            if (!string.IsNullOrEmpty(threadPoolMinThreadsConfig))
            {
                int threadPoolMinThreads = Convert.ToInt32(threadPoolMinThreadsConfig);
                ThreadPool.SetMinThreads(threadPoolMinThreads, threadPoolMinThreads > 1000 ? 1000 : threadPoolMinThreads);
            }

            int workerThreads;
            int ioThreads;
            ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
            Console.WriteLine($"MinThreads: {workerThreads}/{ioThreads}");

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<FooService>(client =>
            {
                client.Timeout = TimeSpan.FromMinutes(10);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
