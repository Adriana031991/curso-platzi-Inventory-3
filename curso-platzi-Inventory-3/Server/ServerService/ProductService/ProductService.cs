
using curso_platzi_Inventory_3.Server.DataAccess;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace curso_platzi_Inventory_3.Server.ServerService.ProductService
{
	public class ProductService : IProductService
	{
		private readonly InventaryContext _context;
		public ProductService(InventaryContext context)
		{
			_context = context;
		}

		public async Task<bool> Delete(string id)
		{
			var dbProduct = await _context.Products.FindAsync(id);
			if (dbProduct == null)
			{
				return false;
			}

			_context.Remove(dbProduct);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<ProductEntity?> GetProductById(string productId)
		{
			var dbProduct = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p=>p.ProductId == productId);
			return dbProduct;
		}

		public async Task<List<ProductEntity>> GetProducts()
		{
			return await _context.Products.Include(p=>p.Category).ToListAsync();
		}

		public async Task<ProductEntity> Save(ProductEntity productEntity)
		{
			_context.Add(productEntity);
			await _context.SaveChangesAsync();
			return productEntity;
		}

		public async Task<ProductEntity> Update(string id, ProductEntity productEntity)
		{
			var dbProduct = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
			if (dbProduct != null)
			{
				dbProduct.ProductName = productEntity.ProductName;
				dbProduct.CategoryId = productEntity.CategoryId;
				dbProduct.ProductDescription = productEntity.ProductDescription;
				dbProduct.TotalQuantity = productEntity.TotalQuantity;

				await _context.SaveChangesAsync();
			}

			return dbProduct;
		}
	}
}
