using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.RicardoCosta.Interfaces
{
   public interface ILogParser
   {
      List<string> Parse(string provider, string logContent);
   }

}
