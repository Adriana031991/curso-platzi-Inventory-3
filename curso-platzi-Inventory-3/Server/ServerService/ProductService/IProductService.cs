using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Server.ServerService.ProductService
{
    public interface IProductService
{
		Task<List<ProductEntity>> GetProducts();
		Task<ProductEntity?> GetProductById(string productId);
		Task<ProductEntity?> Save(ProductEntity productEntity);
		Task<ProductEntity?> Update(string id, ProductEntity productEntity);
		Task<bool> Delete(string id);
	}
}
