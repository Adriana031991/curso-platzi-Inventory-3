
using curso_platzi_Inventory_3.Server.ServerService.CategoryService;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace curso_platzi_Inventory_3.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{

		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}


		[HttpGet]
		public async Task<List<CategoryEntity>> Get()
		{
			return await _categoryService.CategoryList();
		}

		[HttpPost]
		public async Task<CategoryEntity?> CreateCategory(CategoryEntity category)
		{
			return await _categoryService.CreateCategory(category);
		}

		[HttpPut("{id}")]
		public async Task<CategoryEntity?> UpdateCategory(string id, CategoryEntity category)
		{
			return await _categoryService.UpdateCategory(id, category);
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteCategory(string id)
		{
			return await _categoryService.DeleteCategory(id);
		}

	}
}
