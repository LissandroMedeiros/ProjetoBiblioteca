using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                   
            optionsBuilder.UseMySql("Server=localhost;DataBase=Biblioteca;Uid=root;");
        }

        public DbSet<Livro> Livros {get; set;}
        public DbSet<Emprestimo> Emprestimos {get; set;}

        // criando base de dados de usuarios
        public DbSet<Usuario> Usuario {get; set;}

        //DAR O COMANDO NO TERMINAL PARA CRIAR A TABELA: dotnet ef migrations add CreateTableUser
        //DAR O COMANDO NO TERMINAL PARA CRIAR A TABELA: dotnet ef database update


    }
}
