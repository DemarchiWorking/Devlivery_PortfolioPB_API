namespace Devlivery.Authentication.Model
{
    public class RegistroModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public Role Role { get; set; }
    }
}
