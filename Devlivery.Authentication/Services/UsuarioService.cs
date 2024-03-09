using Devlivery.Authentication.Model;
using Devlivery.Authentication.Services.Interfaces;

namespace Devlivery.Authentication.Services
{
    public class UsuarioService : IUsuarioService

    {
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
