using CandidateTesting.RicardoCosta.Interfaces;


namespace CandidateTesting.RicardoCosta.Services
{
   public class LogRecord
   {
      private readonly ILogDownloader _logDownloader;
      private readonly ILogParser _logParser;

      public LogRecord(ILogDownloader logDownloader, ILogParser logParser)
      {
         _logDownloader = logDownloader;
         _logParser = logParser;
      }

      public async Task<string> RunAsync(string provider, string url)
      {
         var logContent = await _logDownloader.DownloadLogAsync(url);


         var parsedData = _logParser.Parse(provider, logContent);
         return string.Join(Environment.NewLine, parsedData);

      }
   }
}
