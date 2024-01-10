using System.Collections.Generic;
using CandidateTesting.RicardoCosta.Interfaces;
using CandidateTesting.RicardoCosta.Services;
using Moq;
using NUnit.Framework;

[TestFixture]
public class LogDownloaderTests
{


   [Test]
   public async Task DownloadLogAsync_ShouldReturnContent()
   {
      var content = "Log content";
      var mockHttpClient = new Mock<IHttpClientWrapper>();
      mockHttpClient.Setup(client => client.GetStringAsync(It.IsAny<string>()))
                    .ReturnsAsync(content);

      var logDownloader = new LogDownloader(mockHttpClient.Object);


      var result = await logDownloader.DownloadLogAsync("http://example.com/log");


      Assert.That(content, Is.EqualTo(result));
   }
}
