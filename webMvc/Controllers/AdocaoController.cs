using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using webMvc.Models;
using Microsoft.Extensions.Options;

public class AdocaoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public AdocaoController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiBaseUrl = apiSettings.Value.BaseUrl;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Adocao");
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var adocoes = JsonSerializer.Deserialize<List<AdocaoViewModel>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(adocoes);
    }

    public IActionResult Create()
    {
        return View(new AdocaoViewModel { DataAdocao = DateTime.Now });
    }

    [HttpPost]
    public async Task<IActionResult> Create(AdocaoViewModel model)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUrl}Adocao", jsonContent);
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Adocao/{id}");
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var adocao = JsonSerializer.Deserialize<AdocaoViewModel>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(adocao);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AdocaoViewModel model)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_apiBaseUrl}Adocao/{model.IdAdocao}", jsonContent);
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Adocao/{id}");
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }
}
