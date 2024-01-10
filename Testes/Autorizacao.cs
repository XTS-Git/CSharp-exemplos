

using System.Data.Common;

namespace NamespaceTeste;

public class autorizador
{
 
   
}


   public enum Roles
   {
      Desenvolvedor = 100,
      Administrador = 10,
      Coordenador = 5,
      operador = 1
   }


public struct Usuario
{
   public int id { get; set; }
   public string nome { get; set; }
   public Roles role { get; set; }
}

public struct UsuarioPerfil
{
   public int id { get; set; }
   public int idUsuario { get; set; }
   public int idPerfil { get; set; }
   
}
public struct Perfil
{
   public int id { get; set; }
   public string nome { get; set; }
}

public struct PerfilModulo
{
   public int id { get; set; }
   public int idPerfil { get; set; }
   public int idModulo { get; set; }
}
public struct Modulos
{
   public int id { get; set; }
   public string nome { get; set; }
   
}


public struct Menu
{
      public decimal id { get; set; }
      public int idModulo { get; set; }
      public string Titulo { get; set; }
      public string Icone { get; set; }
      public string Url { get; set; }
      public decimal Ativo { get; set; }
      public decimal IdPai { get; set; }
}