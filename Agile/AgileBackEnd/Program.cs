
using CandidateTesting.RicardoCosta.Interfaces;
using CandidateTesting.RicardoCosta.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.RicardoCosta.ConsoleApp
{
   public class Program
   {
      const string PROVIDER = "MINHA CDN";
      private static ServiceProvider serviceProvider = ConfigureServices();
      public static async Task Main(string[] args)
      {
         if (!Validation.IsValidParameters(args))
            return;

         var url = args[0];
         if (!Validation.IsValidUrl(url))
         {
            Console.WriteLine("Invalid URL");
            return;
         }

         var output = args[1];
         if (!Validation.IsValidPath(output))
         {
            Console.WriteLine("Invalid path");
            return;
         }

         var logRecord = serviceProvider.GetRequiredService<LogRecord>();

         var result = await logRecord.RunAsync(PROVIDER, url);
         try
         {
            string folder = Path.GetDirectoryName(output);
            string fileName = Path.GetFileName(output);

            if (folder == "") {
               Console.WriteLine("Enter a folder to store the log ");
               return;
            }
            if (fileName == "")
            {
               Console.WriteLine("Enter a file name to store the log ");
               return;
            }
            try
            {
               Directory.CreateDirectory(folder);
            }
            catch (IOException) {  }

            await System.IO.File.WriteAllTextAsync(output, result);

            Console.WriteLine(result);
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
         }
         catch (Exception ex)
         {
            Console.WriteLine($"Error writing file: {ex.Message}");
         }
      }

      public static ServiceProvider ConfigureServices()
      {
         var services = new ServiceCollection();
         services.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();
         services.AddTransient<ILogParser, LogParser>();
         services.AddTransient<ILogDownloader, LogDownloader>();
         services.AddTransient<LogRecord>();
         return services.BuildServiceProvider();
      }

   }


}