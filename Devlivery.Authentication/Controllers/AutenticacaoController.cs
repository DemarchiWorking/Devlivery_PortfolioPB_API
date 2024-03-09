using Devlivery.Authentication.Model;
using Devlivery.Authentication.Model.ValueObject;
using Devlivery.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Devlivery.Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly UserManager<Usuario> _gerenciadorUsuario;
        private readonly SignInManager<Usuario> _gerenciadorAcesso;

        public AutenticacaoController(
            IUsuarioService usuarioService,
            UserManager<Usuario> gerenciadorUsuario, 
            SignInManager<Usuario> gerenciadorAcesso)
        {
            _usuarioService = usuarioService;
            _gerenciadorUsuario = gerenciadorUsuario;
            _gerenciadorAcesso = gerenciadorAcesso;
        }

        [HttpPost]
        public async Task<IActionResult> RegistroUsuarios(RegistroRequisicaoModelDTO model)
        {
            var usuario = new Usuario 
            {   
                Nome = model.Nome,
                Email = model.Email 
            };

            // adicionar await ?? Task<IdentityResult> 
            var resultado = await _gerenciadorUsuario.CreateAsync(
                usuario,
                model.Senha
                );

            if (resultado.Succeeded)
            {
                await _gerenciadorAcesso.SignInAsync(usuario, isPersistent: false);
                return Ok();
            }
            return BadRequest(resultado.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LoginUsuarios(LoginRequisicaoModelDTO model)
        {

            var result = await _gerenciadorAcesso.PasswordSignInAsync(model.Email, model.Senha, model.Relembrar, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }

        //public class AutenticacaoController Index(){ return View();}
        /*public IActionResult Index()
        {
            return null;
        }*/
    }
}
