using Backend.Dtos.Requests;
using Backend.Dtos.Responses;
using Backend.Services.Interfaces;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Obter todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Category>>>> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Obter categoria por ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Categoria encontrada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Category>>> GetById(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Criar nova categoria
        /// </summary>
        /// <param name="categoryRequest">Dados da categoria</param>
        /// <returns>Categoria criada</returns>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Category>>> Create([FromBody] CategoryRequest categoryRequest)
        {
            var result = await _categoryService.CreateAsync(categoryRequest);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Atualizar categoria
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <param name="categoryRequest">Dados atualizados</param>
        /// <returns>Categoria atualizada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Category>>> Update(int id, [FromBody] CategoryRequest categoryRequest)
        {
            var result = await _categoryService.UpdateAsync(id, categoryRequest);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Excluir categoria
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
