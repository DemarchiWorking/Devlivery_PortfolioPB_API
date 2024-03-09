using Devlivery.Authentication.Context;
using Devlivery.Authentication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Devlivery.Infrastructure.Context
{
    public class AplicacaoDbContext : DbContext
    {
        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options) : base(options){}
        public DbSet<Usuario> Usuarios { get; set; }

    }
}

/*
 * 
 *         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=localdb\\MSSQLLocalDB;Initial Catalog=devliverypb;Persist Security Info=True;Trusted_Connection=True;TrustServerCertificate=True",
                    b => b.MigrationsAssembly("Devlivery.Authentication"));
            }
        }
namespace Devlivery.Authentication.Context
{   
    public class AppDbContext : IdentityDbContext<Usuario>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);/*
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Nome = "Test",
                    Email = "test@test.com",
                    Senha = "123"
                })};*/
        
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("Devlivery.Authentication"));
            }
        }
        */
        //protected override void OnModelCreating(ModelBuilder builder){

        //  base.OnModelCreating(builder);
        //}
        /*builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        builder.ApplyConfiguration(new Usuario());

        builder.Entity<Usuario>(new UsuarioMap().Configure);
        builder.Entity<ServicoTrabalho>(new ServicoTrabalhoMap().Configure);            
        builder.Entity<Produto>(new ProdutoMap().Configure);
        base.OnModelCreating(builder);
    }*/

        /* Exemplo de uso:
         //public DbSet<AplicacaoUsuario> AplicacaoUsuarios { get; set; }
            //public DbSet<AplicacaoUsuario> AppUsuario { get; set; }
            //public DbSet<AplicacaoRole> AppRoles { get; set; }

    using (var context = new AuthDbContext(options))
    {
        // Acesse as entidades do contexto aqui.
        // Por exemplo:
        var user = new User
        {
            Nome = "Alice",
            Email = "alice@example.com",
            Senha = "senha123",
            Telefone = "123456789",
            Role = "Admin"
        };

        context.Users.Add(user);
        context.SaveChanges(); } */
    
    //builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
/*
            builder.Entity<Usuario>(new UsuarioMap().Configure);
            builder.Entity<ServicoTrabalho>(new ServicoTrabalhoMap().Configure);            
            builder.Entity<Produto>(new ProdutoMap().Configure);
            */