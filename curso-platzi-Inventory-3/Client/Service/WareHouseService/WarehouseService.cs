
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace curso_platzi_Inventory_3.Client.Service.WareHouseService
{
	public class WarehouseService : IWareHouseService
	{

		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManger;

		public WarehouseService(HttpClient http, NavigationManager navigationManger)
		{
			_http = http;
			_navigationManger = navigationManger;
		}
		public List<WarehouseEntity> WarehousesList { get; set; }

		public async Task Delete(string id)
		{
			await _http.DeleteAsync($"api/Warehouse/{id}");
			//_navigationManger.NavigateTo("product/list");
		}

		public async Task GetWarehouses()
		{
			var result = await _http.GetFromJsonAsync<List<WarehouseEntity>>("api/Warehouse");
			if (result is not null)
				WarehousesList = result.OrderBy(s => s.WarehouseName).ToList();
		}

		public async Task Save(WarehouseEntity warehouse)
		{
			await _http.PostAsJsonAsync("api/Warehouse", warehouse);
			//_navigationManger.NavigateTo("product/list");
		}

		public async Task Update(string id, WarehouseEntity warehouse)
		{
			await _http.PutAsJsonAsync($"api/Warehouse/{id}", warehouse);
			// _navigationManger.NavigateTo("product/list");
		}
	}
}
