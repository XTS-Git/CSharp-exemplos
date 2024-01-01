using System;
using System.Diagnostics;
using System.Threading;
class Program
{
   /// <summary>
   /// o quando a utilização de processamento paralelo impacta no tempo de execução de um programa.
   /// </summary>
   public static void Main()
   {
      long inicio = 200;
      long fim = 800000;
      bool longo = true;

      Console.WriteLine($"Começando com a forma mais demorada faixa: {inicio} /  {fim}");
      var sw = new Stopwatch();
      sw.Start();
      var result = ContarPrimos(inicio, fim, longo);
      sw.Stop();
      Console.WriteLine($"Dev Junior     ->  Resultado: {result} numeros primos encontrados em {sw.ElapsedMilliseconds/1000} segundos, ({Environment.ProcessorCount} processadores)");

      var swD = new Stopwatch();
      swD.Start();
      var resultD = ContarPrimosThreads(inicio, fim, longo);
      swD.Stop();
      Console.WriteLine($"Dev Dinossauro ->  Resultado: {resultD} numeros primos encontrados em {swD.ElapsedMilliseconds/1000} segundos, ({Environment.ProcessorCount} processadores)");      

      var swP = new Stopwatch();
      swP.Start();
      var resultP = ContarPrimosParalel(inicio, fim, longo);
      swP.Stop();
      Console.WriteLine($"Dev Atualizado ->  Resultado: {resultP} numeros primos encontrados em {swP.ElapsedMilliseconds/1000} segundos, ({Environment.ProcessorCount} processadores)");

      Console.WriteLine($"Melhor forma faixa: {inicio} /  {fim}");

      longo = false;
      var sw2 = new Stopwatch();
      sw2.Start();
      var result2 = ContarPrimos(inicio, fim, longo);
      sw2.Stop();
      Console.WriteLine($"Dev Junior     ->  Resultado: {result2} numeros primos encontrados em {sw2.ElapsedMilliseconds / 1000} segundos, ({Environment.ProcessorCount} processadores)");

      var swD2 = new Stopwatch();
      swD2.Start();
      var resultD2 = ContarPrimosThreads(inicio, fim, longo);
      swD2.Stop();
      Console.WriteLine($"Dev Dinossauro ->  Resultado: {resultD2} numeros primos encontrados em {swD2.ElapsedMilliseconds / 1000} segundos, ({Environment.ProcessorCount} processadores)");

      var swP2 = new Stopwatch();
      swP2.Start();
      var resultP2 = ContarPrimosParalel(inicio, fim, longo);
      swP2.Stop();
      Console.WriteLine($"Dev Atualizado ->  Resultado: {resultP2} numeros primos encontrados em {swP2.ElapsedMilliseconds / 1000} segundos, ({Environment.ProcessorCount} processadores)");
   }

   static long ContarPrimos(long inicio, long fin, bool longo = false)
   {
      long contador = 0;
      for (int i = (int)inicio; i < fin; i++)
      {
         if (longo)
         {
            if (PrimoDemorado(i))
               contador++;
         }
         else
         {
            if (Primo(i))
               contador++;
         }
      }
      return contador;
   }

   static long ContarPrimosParalel(long ini, long fim, bool longo = false)
   {
      long contador = 0;
      var lockObject = new object();
      Parallel.For(ini, fim, (Action<long>)(i =>
      {
         if (longo)
         {
            if (Program.PrimoDemorado(i))
            {
               // sincronizo o acesso a variavel contador dentro de todas as threads
               // para que 2 trheads não acessem ao mesmo tempo e alterem o valor
               // desta forma, o valor de contador será sempre o correto
               Interlocked.Increment(ref contador);

            }
         }
         else
         {
            if (Program.Primo(i))
            {
               // sincronizo o acesso a variavel contador dentro de todas as threads
               // para que 2 trheads não acessem ao mesmo tempo e alterem o valor
               // desta forma, o valor de contador será sempre o correto
               Interlocked.Increment(ref contador);

            }
         }
      }));
      return contador;

   }

   static long ContarPrimosThreads(long ini, long fim, bool longo = false)
   {
      long contador = 0;
      var lockObject = new object();
      var faixa = (fim - ini) / Environment.ProcessorCount;
      var numThreads = (long)Environment.ProcessorCount;
      var threads = new Thread[numThreads];
      var tama = faixa / numThreads;
      for (long i = 0; i < numThreads; i++)
      {
         var numInicio = ini + (i * tama);
         var numFim = (i== (numThreads - 1)) ? fim : numInicio + tama;
         threads[i] = new Thread(() =>
         {
            for (long j = numInicio; j < numFim; ++j)
            {
               if (longo)
               {
                  if (PrimoDemorado(j))
                  {
                     // sincronizo o acesso a variavel contador dentro de todas as threads
                     // para que 2 trheads não acessem ao mesmo tempo e alterem o valor
                     // desta forma, o valor de contador será sempre o correto
                     lock (lockObject)
                     {
                        contador++;
                     }
                  }
               }
               else
               {
                  if (Primo(j))
                  {
                     // sincronizo o acesso a variavel contador dentro de todas as threads
                     // para que 2 trheads não acessem ao mesmo tempo e alterem o valor
                     // desta forma, o valor de contador será sempre o correto
                     lock (lockObject)
                     {
                        contador++;
                     }
                  }
               }
            }
         });
         threads[i].Start();
      }

      foreach (var t in threads)
      {
         t.Join();
      }
      return contador;

   }

   static bool PrimoDemorado(long numero)
   {
      if (numero <= 1) return false;
      if (numero == 2) return true;
      if (numero % 2 == 0) return false;      
      // long metade = numero / 2;
      // metade = numero;
      for (long i = 3; i < numero; i += 2)
      {
         if (numero % i == 0)
            return false;
      }
      return true;
   }
   static bool Primo(long numero)
   {
      if (numero <= 1) return false;
      if (numero == 2) return true;
      if (numero % 2 == 0) return false;
      // se um número não é primo, ele terá um fator menor ou igual à sua raiz quadrada.
      var limite = (long)Math.Sqrt(numero);
      for (long i = 3; i <= limite; i += 2)
      {
         if (numero % i == 0)
            return false;
      }
      return true;
   }
}