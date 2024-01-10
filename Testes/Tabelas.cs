

namespace NamespaceTeste;

public class Tabelas
{
 
   public static List<Usuario> CriarTabelaUsuario()
   {
      List<Usuario> usuarios = new List<Usuario>();
      usuarios.Add(new Usuario() { id = 1, nome = "João", role = Roles.Administrador });
      usuarios.Add(new Usuario() { id = 2, nome = "Maria", role = Roles.Coordenador });
      usuarios.Add(new Usuario() { id = 3, nome = "José", role = Roles.operador });
      usuarios.Add(new Usuario() { id = 4, nome = "Pedro", role = Roles.Desenvolvedor });
      return usuarios;
   }

   public static List<Perfil> CriarTabelaPerfil()
   {
      List<Perfil> perfis = new List<Perfil>();
      perfis.Add(new Perfil() { id = 1, nome = "Administrador"});
      perfis.Add(new Perfil() { id = 2, nome = "Coordenador"});
      perfis.Add(new Perfil() { id = 3, nome = "Operador" });
      perfis.Add(new Perfil() { id = 4, nome = "Desenvolvedor" });
      return perfis;
   }

   public static List<Modulos> CriarTabelaModulos()
   {
      List<Modulos> modulos = new List<Modulos>();
      modulos.Add(new Modulos() { id = 1, nome = "Cadastro" });
      modulos.Add(new Modulos() { id = 2, nome = "Financeiro" });
      modulos.Add(new Modulos() { id = 3, nome = "Estoque" });
      modulos.Add(new Modulos() { id = 4, nome = "Vendas" });
      return modulos;
   }

   public static List<PerfilModulo> CriarTabelaPerfilModulo()
   {
      List<PerfilModulo> perfilModulos = new List<PerfilModulo>();
      perfilModulos.Add(new PerfilModulo() { id = 1, idPerfil = 1, idModulo = 1 });
      perfilModulos.Add(new PerfilModulo() { id = 2, idPerfil = 1, idModulo = 2 });
      perfilModulos.Add(new PerfilModulo() { id = 3, idPerfil = 1, idModulo = 3 });
      perfilModulos.Add(new PerfilModulo() { id = 4, idPerfil = 1, idModulo = 4 });
      perfilModulos.Add(new PerfilModulo() { id = 5, idPerfil = 2, idModulo = 1 });
      perfilModulos.Add(new PerfilModulo() { id = 6, idPerfil = 2, idModulo = 2 });
      perfilModulos.Add(new PerfilModulo() { id = 7, idPerfil = 2, idModulo = 3 });
      perfilModulos.Add(new PerfilModulo() { id = 8, idPerfil = 3, idModulo = 1 });
      perfilModulos.Add(new PerfilModulo() { id = 9, idPerfil = 3, idModulo = 2 });
      perfilModulos.Add(new PerfilModulo() { id = 10, idPerfil = 4, idModulo = 1 });
      return perfilModulos;
   }

   public static List<UsuarioPerfil> CriarTabelaUsuarioPerfil()
   {
      List<UsuarioPerfil> usuarioPerfis = new List<UsuarioPerfil>();
      usuarioPerfis.Add(new UsuarioPerfil() { id = 1, idUsuario = 1, idPerfil = 1 });
      usuarioPerfis.Add(new UsuarioPerfil() { id = 2, idUsuario = 2, idPerfil = 2 });
      usuarioPerfis.Add(new UsuarioPerfil() { id = 3, idUsuario = 3, idPerfil = 3 });
      usuarioPerfis.Add(new UsuarioPerfil() { id = 4, idUsuario = 4, idPerfil = 4 });
      return usuarioPerfis;
   }

   public static List<Menu> CriarTabelaMenu()
   {
      List<Menu> menus = new List<Menu>();
      menus.Add(new Menu() { id = 1, idModulo = 1, Titulo = "Cadastro de Clientes", Icone = "fa fa-user" });
      menus.Add(new Menu() { id = 2, idModulo = 1, Titulo = "Cadastro de Produtos", Icone = "fa fa-cubes" });
      menus.Add(new Menu() { id = 3, idModulo = 1, Titulo = "Cadastro de Fornecedores", Icone = "fa fa-truck" });
      menus.Add(new Menu() { id = 4, idModulo = 2, Titulo = "Contas a Pagar", Icone = "fa fa-money" });
      menus.Add(new Menu() { id = 5, idModulo = 2, Titulo = "Contas a Receber", Icone = "fa fa-money" });
      menus.Add(new Menu() { id = 6, idModulo = 3, Titulo = "Entrada de Produtos", Icone = "fa fa-cubes" });
      menus.Add(new Menu() { id = 7, idModulo = 3, Titulo = "Saída de Produtos", Icone = "fa fa-cubes" });
      menus.Add(new Menu() { id = 8, idModulo = 4, Titulo = "Vendas", Icone = "fa fa-shopping-cart" });
      return menus;
   }

}