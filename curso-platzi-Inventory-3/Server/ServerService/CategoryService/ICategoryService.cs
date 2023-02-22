using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Server.ServerService.CategoryService
{
    public interface ICategoryService
{
		Task<List<CategoryEntity>> CategoryList();

		Task<CategoryEntity?> GetCategoryById (string categoryId);
		Task<CategoryEntity?> CreateCategory(CategoryEntity oCategory);
		Task<CategoryEntity?> UpdateCategory(string id, CategoryEntity oCategory);
		Task<bool> DeleteCategory(string id);
	}
}
