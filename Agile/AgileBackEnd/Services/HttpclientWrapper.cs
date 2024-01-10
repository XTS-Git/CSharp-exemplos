using CandidateTesting.RicardoCosta.Interfaces;

namespace CandidateTesting.RicardoCosta.Services
{
   public class HttpClientWrapper : IHttpClientWrapper
   {
      private readonly HttpClient _httpClient;

      public HttpClientWrapper(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<string> GetStringAsync(string url)
      {
         try
         {
            return await _httpClient.GetStringAsync(url);
         }
         catch (Exception ex)
         {
            Console.WriteLine($"Erro ao obter conteúdo da URL: {ex.Message}");
            return string.Empty;
         }
      }
   }

}
