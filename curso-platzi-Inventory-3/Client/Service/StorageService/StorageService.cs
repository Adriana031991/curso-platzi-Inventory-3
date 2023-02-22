
using curso_platzi_Inventory_3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace curso_platzi_Inventory_3.Client.Service.StorageService
{
	public class StorageService : IStorageService
	{

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public StorageService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }
        public List<StorageEntity> StoragesList { get; set; } = new List<StorageEntity>();

        public async Task Delete(string id)
        {
            await _http.DeleteAsync($"api/storage/{id}");
            //_navigationManger.NavigateTo("product/list");
        }

        public async Task<StorageEntity> GetStorageById(string storageId)
        {
            var result = await _http.GetAsync($"api/storage/{storageId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<StorageEntity>();
            }
            return null;
        }

        public async Task GetStorages()
        {
            var result = await _http.GetFromJsonAsync<List<StorageEntity>>("api/storage");
            if (result is not null)
                StoragesList = result.OrderBy(s => s.LastUpdate).ToList();
        }

        public async Task<Dictionary<string, bool>> IsProductInWarehouse(string storageId)
        {
            var response = await _http.GetFromJsonAsync<Dictionary<string, bool>>($"api/storage/isproductinwarehouse/{storageId}");
			Console.WriteLine(" response " + response.FirstOrDefault().ToString());

			// _navigationManger.NavigateTo("product/list");
			return response;
        }

        public async Task Save(StorageEntity storage)
        {
            await _http.PostAsJsonAsync("api/storage", storage);
            //_navigationManger.NavigateTo("product/list");
        }

        public async Task StorageListByWarehouse(string id)
        {
            await _http.GetFromJsonAsync<List<StorageEntity>>($"api/storage/storagelistbywarehouse/{id}");
            // _navigationManger.NavigateTo("product/list");

        }

        public async Task Update(string id, StorageEntity storage)
        {
            await _http.PutAsJsonAsync($"api/storage/{id}", storage);
           // _navigationManger.NavigateTo("product/list");
        }
    }
}
