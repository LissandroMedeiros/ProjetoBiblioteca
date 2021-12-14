//para exibir listas
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {

        // criando CRUD
        
        // método listar
        public List<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.ToList();
            }
        }

// metodo para incluir (recebendo dados Usuario u)
public void IncluirUsuario(Usuario u)
{
     using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Add(u);
                bc.SaveChanges();
            }
}


public void editarUsuario(Usuario EditU)
{

     using(BibliotecaContext bc = new BibliotecaContext())
            {
              
                Usuario antigoU = bc.Usuario.Find(EditU.Id);

                antigoU.Login = EditU.Login;
                antigoU.Nome = EditU.Nome;
                antigoU.Senha = EditU.Senha;
                antigoU.Tipo = EditU.Tipo;

                bc.SaveChanges();
            }
}

public void excluirUsuario(int Id)
{

 using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuario.Remove(bc.Usuario.Find(Id));
                bc.SaveChanges();
            }


}
//BUSCA DE UM USUARIO POR ID (USO PARA EDICAO)
   public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.Find(id);
            }
        }

    }


}