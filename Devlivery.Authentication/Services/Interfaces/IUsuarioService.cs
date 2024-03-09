using Devlivery.Authentication.Model;

namespace Devlivery.Authentication.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Autenticar(string email, string senha);
        Task<Usuario> Registrar(RegistroModel registro);
    }


}
