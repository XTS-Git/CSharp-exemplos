using CandidateTesting.RicardoCosta.Interfaces;

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

}
