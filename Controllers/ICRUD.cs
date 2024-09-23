using mcv_project2024.DO;
using Microsoft.AspNetCore.Mvc;
namespace mcv_project2024.Controllers
{
    public interface ICRUD<T>
    {
      //  Task<IActionResult> Create(T item);
        Task<IActionResult> GetById(int id);
        Task<IActionResult> GetAll();
        Task<IActionResult> Update(int id, T item);
        Task<IActionResult> Delete(int id);
    }
}

