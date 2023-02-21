
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;


namespace curso_platzi_Inventory_3.Client.Service.ProductService
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManger;

		public ProductService(HttpClient http, NavigationManager navigationManger)
		{
			_http = http;
			_navigationManger = navigationManger;
		}
		public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();

		public async Task Delete(string id)
		{
			var result = await _http.DeleteAsync($"api/product/{id}");
			_navigationManger.NavigateTo("product/list");
		}

		public async Task<ProductEntity?> GetProductById(string id)
		{
			var result = await _http.GetAsync($"api/product/{id}");
			if (result.StatusCode == HttpStatusCode.OK)
			{
				return await result.Content.ReadFromJsonAsync<ProductEntity>();
			}
			return null;
		}

		public async Task GetProducts()
		{
			var result = await _http.GetFromJsonAsync<List<ProductEntity>>("api/product");
			if (result is not null)
				Products = result.OrderBy(s => s.ProductName).ToList();

		}

		public async Task Save(ProductEntity productEntity)
		{
			await _http.PostAsJsonAsync("api/product", productEntity);
			_navigationManger.NavigateTo("product/list");
		}

		public async Task Update(string id, ProductEntity productEntity)
		{
			await _http.PutAsJsonAsync($"api/product/{id}", productEntity);
			_navigationManger.NavigateTo("product/list");
		}


	}
}
