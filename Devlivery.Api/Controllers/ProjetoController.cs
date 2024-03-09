using Devlivery.Api.ValueObject;
using Devlivery.Authentication.Model;
using Devlivery.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Devlivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        public ProjetoController()
        {
        }
        [HttpGet]
        public List<string> Listar([FromBody] string email)
        {
            List<string> retorno = new List<string>();
            retorno.Add(email);
            return retorno;
        }/*
        [HttpPost]
        public IActionResult RegistroUsuarios([FromBody] RegistroRequisicaoModelDTO requisicaoRegistro)
        {
            var resultado = "";//await _gerenciarUsuario.CreateAsync(user, requisicaoRegistro.Senha);

            if (resultado != "null")
            {
                //await _gerenciadorAcesso.SignInAsync(usuario, isPersistent: false);
                return Ok();
            }
            return BadRequest();
        }*/
        // Lógica para criar um novo usuário usando o Identity// ...
    }
}
//private readonly UserManager<IdentityUser> _gerenciarUsuario;

//private readonly SignInManager<IdentityUser> _identificadorUsuario;
//UserManager<IdentityUser> gerenciaUsuario,
//SignInManager<IdentityUser> identificadorUsuario
//_gerenciarUsuario = gerenciaUsuario;
//_identificadorUsuario = identificadorUsuario;
