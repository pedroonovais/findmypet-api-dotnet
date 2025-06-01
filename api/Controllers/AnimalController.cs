using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Service;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _service;

        public AnimalController(AnimalService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os animais cadastrados.
        /// </summary>
        /// <response code="200">Lista de animais retornada com sucesso.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var animais = _service.GetAll();
            return Ok(animais);
        }

        /// <summary>
        /// Retorna um animal específico por ID.
        /// </summary>
        /// <param name="id">ID do animal.</param>
        /// <response code="200">Animal encontrado.</response>
        /// <response code="404">Animal não encontrado.</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var animal = _service.GetById(id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        /// <summary>
        /// Cadastra um novo animal.
        /// </summary>
        /// <param name="animal">Dados do animal a ser cadastrado.</param>
        /// <response code="201">Animal criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Animal animal)
        {
            if (animal == null
                || string.IsNullOrWhiteSpace(animal.nomeAnimal)
                || string.IsNullOrWhiteSpace(animal.especie))
            {
                return BadRequest("Dados inválidos.");
            }

            var newAnimal = _service.Create(animal);
            return CreatedAtAction(nameof(GetById), new { id = newAnimal.idAnimal }, newAnimal);
        }

        /// <summary>
        /// Atualiza os dados de um animal existente.
        /// </summary>
        /// <param name="id">ID do animal a ser atualizado.</param>
        /// <param name="animal">Dados atualizados do animal.</param>
        /// <response code="200">Animal atualizado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Animal não encontrado.</response>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(Guid id, [FromBody] Animal animal)
        {
            if (animal == null
                || id == Guid.Empty
                || animal.idAnimal != id
                || string.IsNullOrWhiteSpace(animal.nomeAnimal)
                || string.IsNullOrWhiteSpace(animal.especie))
            {
                return BadRequest("Dados inválidos.");
            }

            var updated = _service.Update(id, animal);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        /// <summary>
        /// Remove um animal pelo ID.
        /// </summary>
        /// <param name="id">ID do animal.</param>
        /// <response code="204">Animal removido com sucesso.</response>
        /// <response code="400">ID inválido.</response>
        /// <response code="404">Animal não encontrado.</response>
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
