using Devlivery.Authentication.DTO;
using Devlivery.Authentication.Model;

namespace Devlivery.Authentication.Services.Interfaces
{
    public interface IUsuarioService
    {
        string CadastrarUsuario(Usuario usuario);
        Task<Usuario> Autenticar(string email, string senha);
        Task<Usuario> Registrar(RegistroModel registro);
    }


}
