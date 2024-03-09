using System.ComponentModel.DataAnnotations;

namespace Devlivery.Authentication.Model.ValueObject
{
    public class LoginRequisicaoModelDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
        public bool Relembrar { get; set; }
    }
}
