using Backend.Dtos.Requests;
using Backend.Dtos.Responses;
using Database.Models;

namespace Backend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<Category>> CreateAsync (CategoryRequest categoryRequest);
        Task<ApiResponse<Category?>> GetByIdAsync(int id);
        Task<ApiResponse<IEnumerable<Category>>> GetAllAsync();
        Task<ApiResponse<Category>> UpdateAsync(int id, CategoryRequest categoryRequest);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
