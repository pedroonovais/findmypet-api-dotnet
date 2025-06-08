namespace web_mvc.Services
{
    public interface IApiService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> CreateAsync(T dto);
        Task<bool> UpdateAsync(int id, T dto);
        Task<bool> DeleteAsync(int id);
    }
}
