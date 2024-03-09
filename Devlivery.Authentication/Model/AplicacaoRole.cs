using Microsoft.AspNetCore.Identity;

namespace Devlivery.Authentication.Model
{
    public class AplicacaoRole : IdentityRole
    {// Adicione propriedades específicas do papel aqui, se necessário.

        public Guid AplicacaoRoleId { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
    }
}
