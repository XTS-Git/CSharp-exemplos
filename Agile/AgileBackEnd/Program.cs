
using CandidateTesting.RicardoCosta.Interfaces;
using CandidateTesting.RicardoCosta.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Net.WebRequestMethods;

namespace CandidateTesting.RicardoCosta.ConsoleApp
{
   public class Program
   {
      //var url = https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt
      const string PROVIDER = "MINHA CDN";
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


         var serviceProvider = ConfigureServices();
         var logRecord = serviceProvider.GetRequiredService<LogRecord>();

         var result = await logRecord.RunAsync(PROVIDER, url);
         try
         {
            string folder = Path.GetDirectoryName(output);

            Directory.CreateDirectory(folder);

            System.IO.File.WriteAllText(output, result);

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