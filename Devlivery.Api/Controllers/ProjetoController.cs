using Devlivery.Authentication.Model;
using Microsoft.AspNetCore.Mvc;

namespace Devlivery.Api.Controllers
{
    public class ProjetoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("CadastrarProjeto")]
        public async Task<IActionResult> CadastrarProjeto()//[FromBody]
        {
            // Lógica para autenticar o usuário e gerar um token JWT
            // ...

            return Ok(new { Token = "seu-token-jwt" });
        }
        /*
         
        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuarioDTO)
        {
            // Lógica para criar um novo usuário usando o Identity
            // ...

            return Ok("Usuário cadastrado com sucesso!");
        }
        */
    }
}
