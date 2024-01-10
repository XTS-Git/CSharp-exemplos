
namespace CandidateTesting.RicardoCosta.Services
{
   public class Validation
   {
      public static bool IsValidPath(string path)
      {
         try
         {
            Path.GetFullPath(path);
            return true;
         }
         catch (Exception)
         {
            return false;
         }
      }



      public static bool IsValidUrl(string url)
      {
         Uri uriResult;
         bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
             && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
         return result;
      }

      public static bool IsValidParameters(string[] args)
      {
         if (args.Length != 2)
         {
            Console.WriteLine("Invalid parameters");
            Console.WriteLine("Enter: Source_Log_Url Destination_Log_Folder");
            return false;
         }
         return true;
      }


   }



}
