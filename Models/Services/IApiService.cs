namespace mcv_project2024.Models.Services
{
    public interface IApiService<T>
    {
        Task<T> AddAsync(T item);
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetAllAsync();

    }
}
