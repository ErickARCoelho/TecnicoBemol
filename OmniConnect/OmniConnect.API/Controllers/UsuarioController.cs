using Microsoft.AspNetCore.Mvc;
using OmniConnect.Aplicacao.DTOs;
using OmniConnect.Aplicacao.Interfaces;

namespace OmniConnect.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    [Tags("Usuários")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        /// <summary>
        /// Cria uma nova conta de usuário com validação de endereço via ViaCEP.
        /// </summary>
        /// <param name="dto">Dados de nome, email e CEP.</param>
        /// <returns>201 Created em caso de sucesso.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CriarUsuario([FromBody] CriarUsuarioDTO dto)
        {
            try
            {
                _usuarioServico.CriarUsuario(dto);
                return Created(string.Empty, new { mensagem = "Usuário criado com sucesso!" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
