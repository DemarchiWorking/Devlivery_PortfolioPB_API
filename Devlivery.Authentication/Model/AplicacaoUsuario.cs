using Microsoft.AspNetCore.Identity;

namespace Devlivery.Authentication.Model
{
    public class AplicacaoUsuario: IdentityUser
    {// Adicione propriedades específicas do papel aqui, se necessário.

        public Guid AplicacaoUsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public Role Role { get; set; }
    }
}
