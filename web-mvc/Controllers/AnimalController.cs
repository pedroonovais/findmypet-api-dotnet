using Microsoft.AspNetCore.Mvc;
using web_mvc.Models;
using web_mvc.Services;

namespace web_mvc.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IApiService<AnimalDto> _service;
        public AnimalController(IApiService<AnimalDto> service) => _service = service;

        public async Task<IActionResult> Index() =>
            View(await _service.GetAllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var animal = await _service.GetByIdAsync(id);
            if (animal == null) return NotFound();
            return View(animal);
        }

        public IActionResult Create() => View(new AnimalDto());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            if (await _service.CreateAsync(dto)) return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "Erro ao criar");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnimalDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            if (await _service.UpdateAsync(id, dto)) return RedirectToAction(nameof(Index));
            ModelState.AddModelError("", "Erro ao atualizar");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
