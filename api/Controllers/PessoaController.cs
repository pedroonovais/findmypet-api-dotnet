using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Service;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _service;

        public PessoaController(PessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var pessoas = _service.GetAll();
            return Ok(pessoas);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            var pessoa = _service.GetById(id);
            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null
                || string.IsNullOrWhiteSpace(pessoa.nomePessoa)
                || string.IsNullOrWhiteSpace(pessoa.cpf))
            {
                return BadRequest("Dados inválidos.");
            }

            var newPessoa = _service.Create(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = newPessoa.idPessoa }, newPessoa);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(Guid id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null
                || id == Guid.Empty
                || pessoa.idPessoa != id
                || string.IsNullOrWhiteSpace(pessoa.nomePessoa)
                || string.IsNullOrWhiteSpace(pessoa.cpf))
            {
                return BadRequest("Dados inválidos.");
            }

            var updated = _service.Update(id, pessoa);
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
