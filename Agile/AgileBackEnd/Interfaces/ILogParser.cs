
namespace CandidateTesting.RicardoCosta.Interfaces
{
   public interface ILogParser
   {
      List<string> Parse(string provider, string logContent);
   }

}
