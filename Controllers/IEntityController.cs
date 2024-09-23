using mcv_project2024.DO;
namespace mcv_project2024.Controllers
{
    public interface IEntityController<T>
    {
        Task<T> AddAsync(T item);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
    }
}

