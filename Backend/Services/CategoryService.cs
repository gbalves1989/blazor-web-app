using Backend.Dtos.Requests;
using Backend.Dtos.Responses;
using Backend.Services.Interfaces;
using Database.Interfaces;
using Database.Models;

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
                Category? categoryExists = await _categoryRepository.GetByNameAsync(categoryRequest.Name);

                if (categoryExists != null)
                {
                    return ApiResponse<Category>.Conflict("Já existe uma categoria com esse nome.");
                }

                Category newCategory = new Category
                {
                    Name = categoryRequest.Name,
                };

                Category createdCategory = await _categoryRepository.CreateAsync(newCategory);

                return ApiResponse<Category>.Created(createdCategory, "Categoria criada com sucesso.");
            }
            catch (Exception ex)
            {
                return ApiResponse<Category>.InternalServerError("Problema ao tentar cadastrar uma categoria.");
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return ApiResponse<bool>.NotFound("Categoria não encontrada.");
            }

            await _categoryRepository.DeleteAsync(category);

            return ApiResponse<bool>.NoContent(true, "Categoria removida com sucesso.");
        }

        public async Task<ApiResponse<IEnumerable<Category>>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();

            return ApiResponse<IEnumerable<Category>>.Ok(categories, "Categorias recuperadas com sucesso.");
        }

        public async Task<ApiResponse<Category?>> GetByIdAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);    

            if (category == null)
            {
                return ApiResponse<Category?>.NotFound("Categoria não encontrada.");
            }

            return ApiResponse<Category?>.Ok(category, "Categoria recuperada com sucesso.");
        }

        public async Task<ApiResponse<Category>> UpdateAsync(int id, CategoryRequest categoryRequest)
        {
            Category? category = _categoryRepository.GetByIdAsync(id).Result;

            if (category == null)
            {
                return ApiResponse<Category>.NotFound("Categoria não encontrada.");
            }

            category.Name = categoryRequest.Name;
            Category updatedCategory = await _categoryRepository.UpdateAsync(category);

            return ApiResponse<Category>.Accept(updatedCategory, "Categoria atualizada com sucesso.");
        }
    }
}
