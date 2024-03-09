using Devlivery.Authentication.Context;
using Devlivery.Authentication.DTO;
using Devlivery.Authentication.Model;
using Devlivery.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Devlivery.Authentication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuarioService(
        AppDbContext context,
        IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);

                var resposta = _context.SaveChanges();

                if (resposta > 0)
                {
                    return "Usuário cadastrado com sucesso.";

                }
                else
                {
                    return "Erro ao cadastradar usuário.";
                     

                }
            }
            catch (Exception e)
            {
                //_logger.Error(e, $"[ListarServicos] Fatal error on ListarServicos");
            }
            return null;


        }
        public Task<Usuario> Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Registrar(RegistroModel registroe)
        {
            throw new NotImplementedException();
        }
    }
}
