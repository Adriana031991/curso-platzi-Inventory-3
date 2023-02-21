

using curso_platzi_Inventory_3.Shared.Entities;

namespace curso_platzi_Inventory_3.Client.Service.ProductService
{
    public interface IProductService
{
		List<ProductEntity> Products { get; set; }
		Task GetProducts();
		Task<ProductEntity?> GetProductById(string id);
		Task Save(ProductEntity productEntity);
		Task Update(string id, ProductEntity productEntity);
		Task Delete(string id);
	}
}
