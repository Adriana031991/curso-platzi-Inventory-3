
using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Client.Service.CategoryService
{
	public interface ICategoryService
{
		List<CategoryEntity> Categories { get; set; }
		Task GetCategories();
		Task<CategoryEntity?> GetCategoryById(string categoryId);
		Task CreateCategory(CategoryEntity oCategory)	;
		Task UpdateCategory(string id, CategoryEntity oCategory);
		Task DeleteCategory(string id);

	}
}
