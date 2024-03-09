using Microsoft.AspNetCore.Identity;

namespace Devlivery.Authentication.Model
{
    public class Usuario : IdentityUser
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
