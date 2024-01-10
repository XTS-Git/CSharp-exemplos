using NUnit.Framework;
using Moq;
using CandidateTesting.RicardoCosta.Interfaces;
using CandidateTesting.RicardoCosta.Services;


namespace CandidateTesting.RicardoCosta.Tests
{
   [TestFixture]
   public class LogRecordTests
   {
      private  Mock<ILogDownloader> _mockLogDownloader;
      private  Mock<ILogParser> _mockLogParser;
      private  LogRecord _logRecord;

      [SetUp]
      public void Setup()
      {
         _mockLogDownloader = new Mock<ILogDownloader>();
         _mockLogParser = new Mock<ILogParser>();
         _logRecord = new LogRecord(_mockLogDownloader.Object, _mockLogParser.Object);
      }

      [Test]
      public async Task RunAsync_ShouldReturnParsedData()
      {

         var provider = "provider";
         var url = "http://example.com";
         var logContent = "log content";
         var parsedData = new List<string> { "parsed data" };

         _mockLogDownloader.Setup(x => x.DownloadLogAsync(url)).ReturnsAsync(logContent);
         _mockLogParser.Setup(x => x.Parse(provider, logContent)).Returns(parsedData);


         var result = await _logRecord.RunAsync(provider, url);


         Assert.That(string.Join(System.Environment.NewLine, parsedData), Is.EqualTo(result));
      }
   }
}
