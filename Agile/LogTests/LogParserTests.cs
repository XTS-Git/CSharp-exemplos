using System.Net.Http;
using System.Threading.Tasks;
using CandidateTesting.RicardoCosta.Services;
using Moq;
using NUnit.Framework;

namespace CandidateTesting.RicardoCosta.Services
{
   [TestFixture]
   public class LogParserTests
   {
      [Test]
      public void Parse_ShouldReturnListOfLines()
      {

         var logContent = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2";
         var logParser = new LogParser();


         var result = logParser.Parse("Test", logContent);

         var expected = new List<string>
         {
            "#Version: 1.0",
            "#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            "#Fields: provider http-method status-code uri-path time-taken response-size cache-status",
            "\"Test\" GET 200 /robots.txt 100.2 312 HIT"
         };

         CollectionAssert.AreEqual(expected, result);

      }
   }
}