using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace curso_platzi_Inventory_3.Server.ServerService.CategoryService
{
	public class CategoryService : ICategoryService
	{

		private readonly InventaryContext _context;
		public CategoryService(InventaryContext context)
		{
			_context = context;
		}



		public async Task<List<CategoryEntity>> CategoryList()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<CategoryEntity?> CreateCategory(CategoryEntity oCategory)
		{
			_context.Add(oCategory);
			await _context.SaveChangesAsync();
			return oCategory;
		}

		public async Task<bool> DeleteCategory(string id)
		{
			var dbCategory = await _context.Categories.FindAsync(id);
			if (dbCategory == null)
			{
				return false;
			}

			_context.Remove(dbCategory);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<CategoryEntity?> GetCategoryById(string categoryId)
		{
			var dbCategory = await _context.Categories.FindAsync(categoryId);
			return dbCategory;
		}

		public async Task<CategoryEntity?> UpdateCategory(string id, CategoryEntity oCategory)
		{
			var dbCategory = await _context.Categories.FindAsync(id);
			if (dbCategory != null)
			{
				dbCategory.CategoryName = oCategory.CategoryName;
				

				await _context.SaveChangesAsync();
			}

			return dbCategory;
		}
	}
}
