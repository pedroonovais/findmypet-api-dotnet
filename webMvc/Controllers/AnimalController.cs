using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using webMvc.Models;
using Microsoft.Extensions.Options;

public class AnimalController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public AnimalController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiBaseUrl = apiSettings.Value.BaseUrl;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Animal");
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var animais = JsonSerializer.Deserialize<List<AnimalViewModel>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(animais);
    }

    public IActionResult Create()
    {
        return View(new AnimalViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(AnimalViewModel model)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUrl}Animal", jsonContent);
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Animal/{id}");
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var animal = JsonSerializer.Deserialize<AnimalViewModel>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(animal);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AnimalViewModel model)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_apiBaseUrl}Animal/{model.IdAnimal}", jsonContent);
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Animal/{id}");
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }
}
