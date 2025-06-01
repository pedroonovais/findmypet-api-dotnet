using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Service;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _service;

        public ReportController(ReportService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var reports = _service.GetAll();
            return Ok(reports);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            var report = _service.GetById(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Report report)
        {
            // Validar FKs como Guid.Empty
            if (report == null
                || report.idPessoa == Guid.Empty
                || report.idAnimal == Guid.Empty
                || report.idLocal == Guid.Empty
                || report.idSensor == Guid.Empty
                || string.IsNullOrWhiteSpace(report.descricaoLocal)
                || string.IsNullOrWhiteSpace(report.statusReport))
            {
                return BadRequest("Dados inválidos.");
            }

            var newReport = _service.Create(report);
            return CreatedAtAction(nameof(GetById), new { id = newReport.idReport }, newReport);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(Guid id, [FromBody] Report report)
        {
            if (report == null
                || id == Guid.Empty
                || report.idReport != id
                || report.idPessoa == Guid.Empty
                || report.idAnimal == Guid.Empty
                || report.idLocal == Guid.Empty
                || report.idSensor == Guid.Empty
                || string.IsNullOrWhiteSpace(report.descricaoLocal)
                || string.IsNullOrWhiteSpace(report.statusReport))
            {
                return BadRequest("Dados inválidos.");
            }

            var updated = _service.Update(id, report);
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
