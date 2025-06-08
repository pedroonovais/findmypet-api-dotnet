using web_mvc.Models;

namespace web_mvc.Services
{
    public class AnimalService : IApiService<AnimalDto>
    {
        private readonly HttpClient _http;
        public AnimalService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ApiClient");
        }
        public async Task<IEnumerable<AnimalDto>> GetAllAsync() =>
            await _http.GetFromJsonAsync<IEnumerable<AnimalDto>>("Animal");

        public async Task<AnimalDto?> GetByIdAsync(int id) =>
            await _http.GetFromJsonAsync<AnimalDto>($"Animal/{id}");

        public async Task<bool> CreateAsync(AnimalDto dto)
        {
            var res = await _http.PostAsJsonAsync("Animal", dto);
            return res.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateAsync(int id, AnimalDto dto)
        {
            var res = await _http.PutAsJsonAsync($"Animal/{id}", dto);
            return res.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _http.DeleteAsync($"Animal/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
