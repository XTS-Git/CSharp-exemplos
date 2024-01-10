/*
 * 
 namespace CandidateTesting.RicardoCosta.ConsoleApp
{
   public class Program
   {
      public static async Task Main(string[] args)
      {
         //if (args.Length != 2)
         //{
         //   Console.WriteLine("Invalid parameters");
         //   Console.WriteLine("Enter: Source_Log_Url Destination_Log_Folder");
         //   return;
         //}
         // var url = args[0];
         var url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
         // var output = args[1];
         var serviceProvider = ConfigureServices();
         var logRecord = serviceProvider.GetRequiredService<LogRecord>();

         var result = await logRecord.RunAsync(url);

         Console.WriteLine(result);
         Console.WriteLine("Pressione Enter para sair...");
         Console.ReadLine();
      }

      private static ServiceProvider ConfigureServices()
      {
         var services = new ServiceCollection();
         services.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();
         services.AddHttpClient<ILogDownloader, LogDownloader>();
         services.AddTransient<ILogParser, LogParser>();
         services.AddTransient<LogRecord>();
         return services.BuildServiceProvider();
      }


      public class LogRecord
      {
         private readonly ILogDownloader _logDownloader;
         private readonly ILogParser _logParser;

         public LogRecord(ILogDownloader logDownloader, ILogParser logParser)
         {
            _logDownloader = logDownloader;
            _logParser = logParser;
         }

         public async Task<string> RunAsync(string url)
         {
            var logContent = await _logDownloader.DownloadLogAsync(url);


            var parsedData = _logParser.Parse(logContent);
            return string.Join(Environment.NewLine, parsedData);

         }
      }




   }
}
namespace CandidateTesting.RicardoCosta.Interfaces
{
   public interface ILogDownloader
   {
      Task<string> DownloadLogAsync(string url);
   }
   public interface IHttpClientWrapper
   {
      Task<string> GetStringAsync(string url);
   }
}

namespace CandidateTesting.RicardoCosta.Interfaces
{
   public interface ILogParser
   {
      List<string> Parse(string logContent);
   }

}

namespace CandidateTesting.RicardoCosta.Services
{

   public class LogDownloader : ILogDownloader
   {
      private readonly IHttpClientWrapper _httpClientWrapper;

      public LogDownloader(IHttpClientWrapper httpClientWrapper)
      {
         _httpClientWrapper = httpClientWrapper;
      }

      public async Task<string> DownloadLogAsync(string url)
      {
         return await _httpClientWrapper.GetStringAsync(url);
      }
   }

   public class HttpClientWrapper : IHttpClientWrapper
   {
      private readonly HttpClient _httpClient;

      public HttpClientWrapper(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<string> GetStringAsync(string url)
      {
         return await _httpClient.GetStringAsync(url);
      }
   }

}

namespace CandidateTesting.RicardoCosta.Services
{
   public class LogParser : ILogParser
   {
      public List<string> Parse(string logContent)
      {

         var lines = logContent.Split('|')
                              .Select(line => line.Trim())
                              .ToList();

         return lines;
      }
   }
}


*/