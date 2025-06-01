using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Service;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdocaoController : ControllerBase
    {
        private readonly AdocaoService _service;

        public AdocaoController(AdocaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var adocoes = _service.GetAll();
            return Ok(adocoes);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var adocao = _service.GetById(id);
            if (adocao == null)
                return NotFound();

            return Ok(adocao);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Adocao adocao)
        {
            // Agora idPessoa e idAnimal são Guid, validamos com Guid.Empty
            if (adocao == null
                || adocao.idPessoa == Guid.Empty
                || adocao.idAnimal == Guid.Empty
                || string.IsNullOrWhiteSpace(adocao.tipoAdocao))
            {
                return BadRequest("Dados inválidos.");
            }

            var newAdocao = _service.Create(adocao);
            return CreatedAtAction(nameof(GetById), new { id = newAdocao.idAdocao }, newAdocao);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(Guid id, [FromBody] Adocao adocao)
        {
            if (adocao == null
                || id == Guid.Empty
                || adocao.idAdocao != id
                || adocao.idPessoa == Guid.Empty
                || adocao.idAnimal == Guid.Empty
                || string.IsNullOrWhiteSpace(adocao.tipoAdocao))
            {
                return BadRequest("Dados inválidos.");
            }

            var updated = _service.Update(id, adocao);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

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
