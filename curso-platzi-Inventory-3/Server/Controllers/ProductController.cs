
using curso_platzi_Inventory_3.Server.ServerService.ProductService;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace curso_platzi_Inventory_3.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}


		[HttpGet]
		public async Task<List<ProductEntity>> Get()
		{
			return await _productService.GetProducts();
		}

		[HttpGet("{id}")]
		public async Task<ProductEntity?> GetProductById(string id)
		{
			return await _productService.GetProductById(id);
		}

		[HttpPost]
		public async Task<ProductEntity?> CreateProduct(ProductEntity product)
		{
			return await _productService.Save(product);
		}

		[HttpPut("{id}")]
		public async Task<ProductEntity?> UpdateProduct(string id, ProductEntity product)
		{
			return await _productService.Update(id, product);
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteProduct(string id)
		{
			return await _productService.Delete(id);
		}

	}
}
