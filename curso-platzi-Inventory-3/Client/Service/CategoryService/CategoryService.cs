
using curso_platzi_Inventory_3.Client.Components.Products;
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace curso_platzi_Inventory_3.Client.Service.CategoryService
{
	public class CategoryService : ICategoryService
	{

		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManger;
		private readonly ILogger<CategoryService> _logger;


		public CategoryService(HttpClient http, NavigationManager navigationManger, ILogger<CategoryService> logger)
		{
			_http = http;
			_navigationManger = navigationManger;
			_logger = logger;
		}
		public List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();

		public async Task GetCategories()
		{
			var result = await _http.GetFromJsonAsync<List<CategoryEntity>>("api/category");
			if (result is not null)
				Categories = result;

		}

		public async Task CreateCategory(CategoryEntity oCategory)
		{
			await _http.PostAsJsonAsync("api/category", oCategory);
			//_navigationManger.NavigateTo("product/list");
		}

		public async Task DeleteCategory(string id)
		{
			await _http.DeleteAsync($"api/category/{id}");
		}

		public async Task UpdateCategory(string id, CategoryEntity oCategory)
		{
			await _http.PutAsJsonAsync($"api/category/{id}", oCategory);
			//_navigationManger.NavigateTo("product/list");
		}


	}
}
