

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
