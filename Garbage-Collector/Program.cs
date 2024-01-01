
class program
{
   static void Main(string[] args)
   {
      var gc1 = GC.CollectionCount(0);
      var gc2 = GC.CollectionCount(1);
      var gc3 = GC.CollectionCount(2);

      var sw = new System.Diagnostics.Stopwatch();
      sw.Start();

      
      for (int i = 0; i < 10000000; i++)
      {
         TestaGC T = new TestaGC();
         // T.Nome = "Teste";
         // remover T da memória, para que o GC possa coletar o objeto
         T = null;
         
      }

      sw.Stop();

      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc1);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc2);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc3);
      Console.WriteLine($"Tempo: {sw.ElapsedMilliseconds} ms");


      Console.WriteLine();
      Console.WriteLine("Diferença usando struct");
      var gc12 = GC.CollectionCount(0);
      var gc22 = GC.CollectionCount(1);
      var gc32 = GC.CollectionCount(2);

      var sw2 = new System.Diagnostics.Stopwatch();
      sw2.Start();


      for (int i = 0; i < 10000000; i++)
      {
         TestaGC2 T = new TestaGC2();
         T.Nome = "Teste";
      }

      sw2.Stop();

      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc12);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc22);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc32);
      Console.WriteLine($"Tempo: {sw2.ElapsedMilliseconds} ms");


      Console.WriteLine();
      Console.WriteLine("Diferença usando struct grandes");
      var gc13 = GC.CollectionCount(0);
      var gc23 = GC.CollectionCount(1);
      var gc33 = GC.CollectionCount(2);

      var sw3 = new System.Diagnostics.Stopwatch();
      sw3.Start();


      for (int i = 0; i < 10000000; i++)
      {
         TestaGC3 T = new TestaGC3();
         // T.Nome = "Teste";
      }

      sw3.Stop();

      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc13);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc23);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc33);
      Console.WriteLine($"Tempo: {sw3.ElapsedMilliseconds} ms");


   }
}

class TestaGC 
{
   public string Nome { get; set; }

   public TestaGC()
   {
      Nome = "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
   }

}

struct TestaGC2
{
   public string Nome { get; set; }
}


struct TestaGC3
{
   public string Nome { get; set; }

   public TestaGC3()
   {
      Nome = "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
      Nome += "sdfsljkdh ljkhdf lsjkhdf sljkfh slfjkh slfjhs lfdjhslfjh slfjh slfjsh lfj ljkh sdlfjh lsjkfh sljfdh sljkfh slfjh sljkhfslj fhsjkl fh";
   }
}