using Devlivery.Authentication.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Data;

namespace Devlivery.Authentication.Data
{
    public class AuthDbContext : IdentityDbContext<AplicacaoUsuario>
    {
        //public DbSet<AplicacaoUsuario> AppUsuario { get; set; }
        //public DbSet<AplicacaoRole> AppRoles { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<Usuario> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
    /* Exemplo de uso:

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

}
