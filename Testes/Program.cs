using System;
using System.Collections.Generic;
using System.Data;
class program
{
   static void Main(string[] args)
   {

      DataTable dtb;
      List<MenuDto> lDto;
      List<sMenuDto> lStr;
      int vezes = 1_000_000;
      #region 
      Console.WriteLine($"Inicia Class com DaTaTable *************************************************************************");    
      var gc1 = GC.CollectionCount(0);
      var gc2 = GC.CollectionCount(1);
      var gc3 = GC.CollectionCount(2);

      var sw = new System.Diagnostics.Stopwatch();
      sw.Start();

      int contador = 0;
      dtb = new DataTable();
      for (int i = 0; i < vezes; i++)
      {
         MenuDto T = new MenuDto(){
            id = contador++,
            Titulo = "Teste",
            Icone = "Teste",
            Url = "Teste",
            Ativo = 1,
            IdPai = 1,
            Role = "Teste"
         };
         DataRow dtr = T.DtoParaDataRow();
         dtb.ImportRow(dtr);
         
      }

      sw.Stop();

      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc1);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc2);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc3);
      Console.WriteLine($"Tempo: {sw.ElapsedMilliseconds} ms");
      #endregion

      #region
      Console.WriteLine($"Inicia Class com List<> *******************************************************");
      var gc13 = GC.CollectionCount(0);
      var gc23 = GC.CollectionCount(1);
      var gc33 = GC.CollectionCount(2);

      var sw3 = new System.Diagnostics.Stopwatch();
      sw3.Start();

      int contador3 = 0;
      lDto = new List<MenuDto>();
      for (int i = 0; i < vezes; i++)
      {
         MenuDto T = new MenuDto()
         {
            id = contador3++,
            Titulo = "Teste",
            Icone = "Teste",
            Url = "Teste",
            Ativo = 1,
            IdPai = 1,
            Role = "Teste"
         };
         lDto.Add(T);
      }

      sw3.Stop();
      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc13);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc23);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc33);
      Console.WriteLine($"Tempo: {sw3.ElapsedMilliseconds} ms");
      #endregion

      #region
      Console.WriteLine($"Inicia Struct DataTable");

      var gc12 = GC.CollectionCount(0);
      var gc22 = GC.CollectionCount(1);
      var gc32 = GC.CollectionCount(2);

      var sw2 = new System.Diagnostics.Stopwatch();
      sw2.Start();

      int contador2 = 0;
      dtb = new DataTable();
      for (int i = 0; i < vezes; i++)
      {
         sMenuDto T = new sMenuDto(){
            id = contador2++,
            Titulo = "Teste",
            Icone = "Teste",
            Url = "Teste",
            Ativo = 1,
            IdPai = 1,
            Role = "Teste"
         };
         DataRow dtr = T.DtoParaDataRow();
         dtb.ImportRow(dtr);         
         
      }

      sw2.Stop();

      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc12);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc22);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc32);
      Console.WriteLine($"Tempo: {sw2.ElapsedMilliseconds} ms");
      #endregion

      #region
      Console.WriteLine($"Inicia Struct List<>");

      var gc124 = GC.CollectionCount(0);
      var gc224 = GC.CollectionCount(1);
      var gc324 = GC.CollectionCount(2);

      var sw24 = new System.Diagnostics.Stopwatch();
      sw24.Start();

      int contador24 = 0;
      lStr = new List<sMenuDto>();
      for (int i = 0; i < vezes; i++)
      {
         sMenuDto T = new sMenuDto()
         {
            id = contador24++,
            Titulo = "Teste",
            Icone = "Teste",
            Url = "Teste",
            Ativo = 1,
            IdPai = 1,
            Role = "Teste"
         };
         lStr.Add(T);

      }

      sw24.Stop();

      Console.WriteLine("GC Gen #0: {0}", GC.CollectionCount(0) - gc124);
      Console.WriteLine("GC Gen #1: {0}", GC.CollectionCount(1) - gc224);
      Console.WriteLine("GC Gen #2: {0}", GC.CollectionCount(2) - gc324);
      Console.WriteLine($"Tempo: {sw24.ElapsedMilliseconds} ms");
      #endregion

   }
}



public class MenuDto
{
   public MenuDto()
   {
      ATIVO = 0;
      ID_PAI = 0;
   }
   private decimal ID_ITEM;
   private string TITULO;
   private string ICONE;
   private string URL;
   private decimal ATIVO;
   private decimal ID_PAI;
   private string ROLE;

   public decimal id { get { return ID_ITEM; } set { ID_ITEM = value; } }
   public string Titulo { get { return TITULO; } set { TITULO = value; } }
   public string Icone { get { return ICONE; } set { ICONE = value; } }
   public string Url { get { return URL; } set { URL = value; } }
   public decimal Ativo { get { return ATIVO; } set { ATIVO = value; } }
   public decimal IdPai { get { return ID_PAI; } set { ID_PAI = value; } }
   public string Role { get { return ROLE; } set { ROLE = value; } }

   public DataRow DtoParaDataRow()
   {
      DataTable dtb = new DataTable();
      DataRow dtr = CriarNovaLinhaTable(dtb);
      dtb.ImportRow(dtr);
      return this.DtoParaDataRow(dtb);
   }

   /// <summary>
   /// Configura DataRow para ser usado em DataTable
   /// </summary>
   /// <returns></returns>
   public DataRow CriarNovaLinhaTable(DataTable dtb)
   {
      DataRow dtr = dtb.NewRow();
      dtr.Table.Columns.Add("ID_ITEM", typeof(string));
      dtr.Table.Columns.Add("TITULO", typeof(string));
      dtr.Table.Columns.Add("ICONE", typeof(string));
      dtr.Table.Columns.Add("URL", typeof(string));
      dtr.Table.Columns.Add("ATIVO", typeof(string));
      dtr.Table.Columns.Add("ID_PAI", typeof(string));
      dtr.Table.Columns.Add("ROLE", typeof(string));
      return dtr;
   }

   /// <summary>
   /// Cria DataRow a partir de um Dto que ja exista Dados
   /// </summary>
   /// <param name="dtb"></param>
   /// <returns></returns>
   public DataRow DtoParaDataRow(DataTable dtb)
   {
      DataRow dtr = dtb.NewRow();
      if (ID_ITEM != null) dtr["ID_ITEM"] = this.ID_ITEM;
      if (TITULO != null) dtr["TITULO"] = this.TITULO;
      if (ICONE != null) dtr["ICONE"] = this.ICONE;
      if (URL != null) dtr["URL"] = this.URL;
      if (ATIVO != null) dtr["ATIVO"] = this.ATIVO;
      if (ID_PAI != null) dtr["ID_PAI"] = this.ID_PAI;
      if (ROLE != null) dtr["ROLE"] = this.ROLE;
      return dtr;
   }

   public MenuDto ConverteDataRowParaPessoaDto(DataRow dtr)
   {
      if (dtr.Table.Columns.Contains("ID_ITEM")) this.ID_ITEM = dtr["ID_ITEM"].ToDecimal();
      if (dtr.Table.Columns.Contains("TITULO")) this.TITULO = dtr["TITULO"].ToString();
      if (dtr.Table.Columns.Contains("ICONE")) this.ICONE = dtr["ICONE"].ToString();
      if (dtr.Table.Columns.Contains("URL")) this.URL = dtr["URL"].ToString();
      if (dtr.Table.Columns.Contains("ATIVO")) this.ATIVO = dtr["ATIVO"].ToDecimal();
      if (dtr.Table.Columns.Contains("ID_PAI")) this.ID_PAI = dtr["ID_PAI"].ToDecimal();
      if (dtr.Table.Columns.Contains("ROLE")) this.ROLE = dtr["ROLE"].ToString();
      return this;
   }

   ///// <summary>
   ///// Cria um List a partir de um DataTable
   ///// </summary>
   public List<MenuDto> DataTableToList(DataTable dtb)
   {
      int tamanho = dtb.Rows.Count;
      List<MenuDto> lista = new List<MenuDto>(tamanho);
      for (int i = 0; i < tamanho; i++)
      {
         // PessoaDto dto = new PessoaDto();
         lista.Add(ConverteDataRowParaPessoaDto(dtb.Rows[i]));
      }
      return lista;
   }


}


public struct sMenuDto
{
   public sMenuDto()
   {
      ATIVO = 0;
      ID_PAI = 0;
   }
   private decimal ID_ITEM;
   private string TITULO;
   private string ICONE;
   private string URL;
   private decimal ATIVO;
   private decimal ID_PAI;
   private string ROLE;

   public decimal id { get { return ID_ITEM; } set { ID_ITEM = value; } }
   public string Titulo { get { return TITULO; } set { TITULO = value; } }
   public string Icone { get { return ICONE; } set { ICONE = value; } }
   public string Url { get { return URL; } set { URL = value; } }
   public decimal Ativo { get { return ATIVO; } set { ATIVO = value; } }
   public decimal IdPai { get { return ID_PAI; } set { ID_PAI = value; } }
   public string Role { get { return ROLE; } set { ROLE = value; } }

   public DataRow DtoParaDataRow()
   {
      DataTable dtb = new DataTable();
      DataRow dtr = CriarNovaLinhaTable(dtb);
      dtb.ImportRow(dtr);
      return this.DtoParaDataRow(dtb);
   }

   /// <summary>
   /// Configura DataRow para ser usado em DataTable
   /// </summary>
   /// <returns></returns>
   public DataRow CriarNovaLinhaTable(DataTable dtb)
   {
      DataRow dtr = dtb.NewRow();
      dtr.Table.Columns.Add("ID_ITEM", typeof(string));
      dtr.Table.Columns.Add("TITULO", typeof(string));
      dtr.Table.Columns.Add("ICONE", typeof(string));
      dtr.Table.Columns.Add("URL", typeof(string));
      dtr.Table.Columns.Add("ATIVO", typeof(string));
      dtr.Table.Columns.Add("ID_PAI", typeof(string));
      dtr.Table.Columns.Add("ROLE", typeof(string));
      return dtr;
   }

   /// <summary>
   /// Cria DataRow a partir de um Dto que ja exista Dados
   /// </summary>
   /// <param name="dtb"></param>
   /// <returns></returns>
   public DataRow DtoParaDataRow(DataTable dtb)
   {
      DataRow dtr = dtb.NewRow();
      if (ID_ITEM != null) dtr["ID_ITEM"] = this.ID_ITEM;
      if (TITULO != null) dtr["TITULO"] = this.TITULO;
      if (ICONE != null) dtr["ICONE"] = this.ICONE;
      if (URL != null) dtr["URL"] = this.URL;
      if (ATIVO != null) dtr["ATIVO"] = this.ATIVO;
      if (ID_PAI != null) dtr["ID_PAI"] = this.ID_PAI;
      if (ROLE != null) dtr["ROLE"] = this.ROLE;
      return dtr;
   }

   public sMenuDto ConverteDataRowParaPessoaDto(DataRow dtr)
   {
      if (dtr.Table.Columns.Contains("ID_ITEM")) this.ID_ITEM = dtr["ID_ITEM"].ToDecimal();
      if (dtr.Table.Columns.Contains("TITULO")) this.TITULO = dtr["TITULO"].ToString();
      if (dtr.Table.Columns.Contains("ICONE")) this.ICONE = dtr["ICONE"].ToString();
      if (dtr.Table.Columns.Contains("URL")) this.URL = dtr["URL"].ToString();
      if (dtr.Table.Columns.Contains("ATIVO")) this.ATIVO = dtr["ATIVO"].ToDecimal();
      if (dtr.Table.Columns.Contains("ID_PAI")) this.ID_PAI = dtr["ID_PAI"].ToDecimal();
      if (dtr.Table.Columns.Contains("ROLE")) this.ROLE = dtr["ROLE"].ToString();
      return this;
   }

   ///// <summary>
   ///// Cria um List a partir de um DataTable
   ///// </summary>
   public List<sMenuDto> DataTableToList(DataTable dtb)
   {
      int tamanho = dtb.Rows.Count;
      List<sMenuDto> lista = new List<sMenuDto>(tamanho);
      for (int i = 0; i < tamanho; i++)
      {
         // PessoaDto dto = new PessoaDto();
         lista.Add(ConverteDataRowParaPessoaDto(dtb.Rows[i]));
      }
      return lista;
   }


}

public static class ObjectExtensions
{
   public static bool IsNull(this object? o)
   {
      if (o == null)
         return true;
      else if (o.ToString() == string.Empty)
         return true;
      else
         return false;
   }
   public static bool IsNullOrEmpty(this object? o)
   {
      if (o == null)
         return true;
      else if (o.ToString() == string.Empty)
         return true;
      else
         return false;
   }

   public static bool IsNullOrZero(this object? o)
   {
      bool retorno = false;
      if (o == null)
         retorno = true;
      if (o.IsNull())
         retorno = true;
      else if (o.ToString() == "0")
         retorno = true;
      return retorno;
   }

   public static double ToDouble(this object o)
   {
      if (o.IsNull())
      {
         return 0;
      }
      else
         return Convert.ToDouble(o);
   }

   public static decimal ToDecimal(this object o)
   {
      if (o.IsNull())
      {
         return 0;
      }
      else
         return Convert.ToDecimal(o);
   }

   public static int ToInt(this object o)
   {
      if (o.IsNull())
      {
         return 0;
      }
      else
         return Convert.ToInt16(o);
   }

   public static Int64 ToInt64(this object o)
   {
      if (o.IsNull())
      {
         return 0;
      }
      else
         return Convert.ToInt64(o);
   }



   public static string toString(this object o)
   {
      if (!o.IsNull())
      {
         return o.ToString();
      }
      else
      {
         return string.Empty;
      }
   }

   public static DateTime? ToDateTime(this object o)
   {
      if (o.IsNull())
      {
         return null;
      }
      else
         return Convert.ToDateTime(o);
   }

}

