using Microsoft.AspNetCore.Mvc;
using Projeto4Bio.Models;
using Projeto4Bio.Services;

namespace Projeto4Bio.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet("listar")]
        public IActionResult Listar([FromQuery] string? nome = null, [FromQuery] string? email = null, [FromQuery] string? cpf = null)
        {
            var resultado = _service.Listar(nome, email, cpf);
            return Ok(resultado);
        }


        [HttpPost("criar")]
        public IActionResult Criar([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novo = _service.Criar(cliente);
            return CreatedAtAction(nameof(Listar), new { id = novo.Id }, novo);
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            var atualizado = _service.Atualizar(id, cliente);
            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

        [HttpDelete("remover/{id}")]
        public IActionResult Remover(int id)
        {
            var removido = _service.Remover(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
