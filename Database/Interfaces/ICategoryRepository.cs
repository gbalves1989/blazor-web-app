using Database.Models;

namespace Database.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> GetByNameAsync(string name);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
    }
}
