using Devlivery.Api.ValueObject;
using Devlivery.Authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Devlivery.Api.Controllers
{

    public class AutenticacaoController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _gerenciarUsuario;

        private readonly SignInManager<IdentityUser> _identificadorUsuario;

        public AutenticacaoController(
            UserManager<IdentityUser> gerenciaUsuario,
            SignInManager<IdentityUser> identificadorUsuario)
        {
            _gerenciarUsuario = gerenciaUsuario;
            _identificadorUsuario = identificadorUsuario;

        }

        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> RegistroUsuario([FromBody] RegistroRequisicaoModelDTO requisicaoRegistro)
        {
            if (String.IsNullOrEmpty(requisicaoRegistro?.Email))
            {
                return null;
            }
            if (String.IsNullOrEmpty(requisicaoRegistro?.Senha))
            {
                return null;
            }
            if (String.IsNullOrEmpty(requisicaoRegistro?.Telefone))
            {
                return null;
            }
            if (String.IsNullOrEmpty(requisicaoRegistro?.Nome))
            {
                return null;
            }
            var user = new IdentityUser
            {
                UserName = requisicaoRegistro.Nome,
                Email = requisicaoRegistro.Email,
            };

            var result = await _gerenciarUsuario.CreateAsync(user,
                requisicaoRegistro.Senha);

            if (result.Succeeded)
            {

                return Ok("Usuário cadastrado com sucesso!");
            }
            else
            {
                return BadRequest();
            }
            // Lógica para criar um novo usuário usando o Identity
            // ...
        }

        [HttpPost("LoginUsuario")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginRequisicaoModelDTO loginViewModel)
        {
            // Lógica para autenticar o usuári


            var user = new IdentityUser
            {
                Email = loginViewModel.Email,
            };

            var result = await _identificadorUsuario.PasswordSignInAsync(user,
                loginViewModel.Senha, loginViewModel.Relembra,
                false);

            if (result.Succeeded)
            {

                return Ok("Usuário cadastrado com sucesso!");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("Listar")]
        public List<string> Listar([FromBody] string email)
        {
            List<string> retorno = new List<string>();
            retorno.Add(email);
            return retorno;
        }


    }
}
