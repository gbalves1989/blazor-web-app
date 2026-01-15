using Backend.Dtos.Requests;
using Backend.Dtos.Responses;
using Backend.Services.Interfaces;
using Database.Interfaces;
using Database.Models;
using Microsoft.Data.SqlClient;

namespace Backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<Category>> CreateAsync(CategoryRequest categoryRequest)
        {
            try
            {
                Category newCategory = new Category
                {
                    Name = categoryRequest.Name,
                };

                Category createdCategory = await _categoryRepository.CreateAsync(newCategory);

                return ApiResponse<Category>.Created(createdCategory, "Categoria criada com sucesso.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
                {
                    return ApiResponse<Category>.Conflict("Nome da categoria já está cadastrado."); 
                }
                else
                {
                    return ApiResponse<Category>.InternalServerError("Problema ao tentar cadastrar uma categoria.");
                }
            }
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<Category>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Category?>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Category>> UpdateAsync(int id, CategoryRequest categoryRequest)
        {
            throw new NotImplementedException();
        }
    }
}
