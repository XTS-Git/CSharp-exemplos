using CandidateTesting.RicardoCosta.Interfaces;


namespace CandidateTesting.RicardoCosta.Services
{
   public class LogParser : ILogParser
   {
      public List<string> Parse(string provider, string logContent)
      {

         var parsedLines = new List<string>();

         parsedLines.Add("#Version: 1.0");
         parsedLines.Add($"#Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
         parsedLines.Add("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");

         var lines = logContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

         foreach (var line in lines)
         {
            var fields = line.Split('|');

            if (fields.Length == 5)
            {
               var httpMethod = fields[3].Replace("\"","").Split(' ')[0];
               var statusCode = fields[1];
               var uriPath = fields[3].Split(' ')[1];
               var timeTaken = fields[4];


               parsedLines.Add($"\"{provider}\" {httpMethod} {statusCode} {uriPath} {timeTaken} {fields[0]} {fields[2]}");
            }
         }

         return parsedLines;
      }
   }
}
