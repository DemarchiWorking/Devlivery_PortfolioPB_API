using System.ComponentModel.DataAnnotations;

namespace Devlivery.Api.ValueObject
{
    public class LoginRequisicaoModelDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
        public bool Relembra { get; set; } = false;

    }
}
