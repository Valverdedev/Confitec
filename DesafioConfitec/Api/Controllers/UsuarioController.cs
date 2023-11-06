using Application;
using Application.Dtos.UsuarioDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("InserirUsuario")]
        [ProducesResponseType(typeof(ObjetoDeRetorno<UsuarioDto>), 200)]
        public async Task<IActionResult> InserirUsuario([FromBody] InserirUsuarioDto usuarioDto)
        {
           return Ok(await _usuarioAppService.InserirAsync(usuarioDto));
        }

        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(typeof(ObjetoDeRetorno<IList<UsuarioDto>>), 200)]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await _usuarioAppService.ListarTodosAsync());
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        [ProducesResponseType(typeof(ObjetoDeRetorno<UsuarioDto>), 200)]
        public async Task<IActionResult> ObterPorId(int id)
        {
            return Ok(await _usuarioAppService.ObterPorIdAsync(id));
        }

        [HttpDelete]
        [Route("ExcluirUsuario/{id}")]
        [ProducesResponseType(typeof(ObjetoDeRetorno<UsuarioDto>), 200)]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            return Ok(await _usuarioAppService.ExcluirAsync(id));
        }

        [HttpPut]
        [Route("AtualizarUsuario/{id}")]
        [ProducesResponseType(typeof(ObjetoDeRetorno<UsuarioDto>), 200)]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] InserirUsuarioDto inserirUsuarioDto)
        {
            return Ok(await _usuarioAppService.AtualizarAsync(id, inserirUsuarioDto));
        }

    }
}
