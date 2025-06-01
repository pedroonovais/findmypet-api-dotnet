using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Service;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly LocalService _service;

        public LocalController(LocalService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os locais cadastrados.
        /// </summary>
        /// <response code="200">Lista de locais retornada com sucesso.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var locais = _service.GetAll();
            return Ok(locais);
        }

        /// <summary>
        /// Retorna um local específico por ID.
        /// </summary>
        /// <param name="id">ID do local.</param>
        /// <response code="200">Local encontrado.</response>
        /// <response code="404">Local não encontrado.</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var local = _service.GetById(id);
            if (local == null)
                return NotFound();

            return Ok(local);
        }

        /// <summary>
        /// Cadastra um novo local.
        /// </summary>
        /// <param name="local">Dados do local a ser cadastrado.</param>
        /// <response code="201">Local criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Local local)
        {
            if (local == null
                || string.IsNullOrWhiteSpace(local.cidade)
                || string.IsNullOrWhiteSpace(local.estado))
            {
                return BadRequest("Dados inválidos.");
            }

            var newLocal = _service.Create(local);
            return CreatedAtAction(nameof(GetById), new { id = newLocal.idLocal }, newLocal);
        }

        /// <summary>
        /// Atualiza os dados de um local existente.
        /// </summary>
        /// <param name="id">ID do local a ser atualizado.</param>
        /// <param name="local">Dados atualizados do local.</param>
        /// <response code="200">Local atualizado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Local não encontrado.</response>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(Guid id, [FromBody] Local local)
        {
            if (local == null
                || id == Guid.Empty
                || local.idLocal != id
                || string.IsNullOrWhiteSpace(local.cidade)
                || string.IsNullOrWhiteSpace(local.estado))
            {
                return BadRequest("Dados inválidos.");
            }

            var updated = _service.Update(id, local);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        /// <summary>
        /// Remove um local pelo ID.
        /// </summary>
        /// <param name="id">ID do local.</param>
        /// <response code="204">Local removido com sucesso.</response>
        /// <response code="400">ID inválido.</response>
        /// <response code="404">Local não encontrado.</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
