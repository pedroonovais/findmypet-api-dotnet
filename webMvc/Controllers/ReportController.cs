using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using webMvc.Models;
using Microsoft.Extensions.Options;
using webMvc.Controllers;

public class ReportController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public ReportController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiBaseUrl = apiSettings.Value.BaseUrl;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Report");
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var reports = JsonSerializer.Deserialize<List<ReportViewModel>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(reports);
    }

    public IActionResult Create()
    {
        return View(new ReportViewModel { DataReport = DateTime.Now });
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReportViewModel model)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUrl}Report", jsonContent);
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Report/{id}");
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var report = JsonSerializer.Deserialize<ReportViewModel>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(report);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ReportViewModel model)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_apiBaseUrl}Report/{model.IdReport}", jsonContent);
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Report/{id}");
        response.EnsureSuccessStatusCode();

        return RedirectToAction(nameof(Index));
    }
}
